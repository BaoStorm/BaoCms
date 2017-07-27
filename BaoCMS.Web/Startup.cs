using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BaoCMS.Data.Configuration;
using BaoCMS.Data.Extensions;
using BaoCMS.Web.Extensions;
using Autofac;
using BaoCMS.Web;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Razor;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using BaoCMS.Web.Validators;
using IdentityServer4;
using IdentityServer4.Models;

namespace BaoCMS
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<Data.Configuration.Data>(Configuration.GetSection("Data"));

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });


            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddEntityFramework(Configuration);
            // Add framework services.



            services.AddMvc()
                .AddJsonOptions(r => r.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());

            services.AddAutoMapper();

            services.RegisterCustomServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "BaoCMS WebApI 生成文档（文档说明）",
                    Version = "v1"
                });
                //Determine base path for the application.  
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                ////Set the comments path for the swagger json and ui.  
                //var xmlPath = Path.Combine(basePath, "BaoCMS.Web.xml");
                //c.IncludeXmlComments(xmlPath);
            });

            var identityServerBuilder = services.AddIdentityServer();
            identityServerBuilder
                .AddDeveloperSigningCredential("tempkey.rsa") //添加证书 没有自动创建
                //.AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients());

            identityServerBuilder.AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();

            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacModule());
            builder.Populate(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            app.AddDevMiddlewares();

            app.EnsureDbCreated();
            app.EnsureIdentityCreatedAsync();

            //app.UseIdentity();//启用netcore 自带的用户管理

            app.UseIdentityServer();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "defaultWebApi",
                    template: "api/{controller}/{action=Index}/{id?}");
            });


        }
    }
}
