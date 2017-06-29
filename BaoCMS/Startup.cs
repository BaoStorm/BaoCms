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

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

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
            services.AddMvc();

            services.AddAutoMapper();

            var builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacModule());
            builder.Populate(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.EnsureDbCreated();
            app.EnsureIdentityCreatedAsync();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

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
                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
