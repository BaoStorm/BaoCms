using AutoMapper;
using BaoCMS.Data.Domain;
using BaoCMS.Data.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoCMS.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var hostingEnvironment = services.BuildServiceProvider().GetService<IHostingEnvironment>();

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile(new ApiAutoMapperProfile());
                cfg.AddProfile(new DomainAutoMapperProfile());
                cfg.AddProfile(new ReportingAutoMapperProfile());
                
            });

            services.AddSingleton(sp => autoMapperConfig.CreateMapper());

            return services;
        }
    }
}
