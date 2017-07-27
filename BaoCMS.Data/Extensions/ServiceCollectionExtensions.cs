using BaoCMS.Data.Entities;
using BaoCMS.Framework.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BaoCMS.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var dataProviderConfig = configuration.GetSection("Data")["Provider"];
            var connectionStringConfig = configuration.GetConnectionString("DefaultConnection");

            var currentAssembly = typeof(ServiceCollectionExtensions).GetTypeInfo().Assembly;
            var dataProviders = currentAssembly.GetImplementationsOf<IDataProvider>();

            var dataProvider = dataProviders.SingleOrDefault(x => x.Provider.ToString() == dataProviderConfig);

            dataProvider.RegisterDbContext(services, connectionStringConfig);

            //services.AddIdentity<User, Role>()
            //    .AddEntityFrameworkStores<DbContext, Guid>()
            //    .AddDefaultTokenProviders();

            return services;
        }

        //public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        //{
        //    var autoMapperConfig = new MapperConfiguration(cfg =>
        //    {
        //        var currentAssembly = typeof(ServiceCollectionExtensions).GetTypeInfo().Assembly;
        //        var profiles = currentAssembly.GetTypes<Profile>();

        //        foreach (var profile in profiles)
        //        {
        //            cfg.AddProfile(profile);
        //        }
        //    });

        //    services.AddSingleton(sp => autoMapperConfig.CreateMapper());

        //    return services;
        //}
    }
}
