using Autofac;
using BaoCMS.Data;
using BaoCMS.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BaoCMS.Web
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var infrastructureAssembly = typeof(AggregateRoot).GetTypeInfo().Assembly;
            //var domainAssembly = typeof(CreateSite).GetTypeInfo().Assembly;
            var dataAssembly = typeof(IDataProvider).GetTypeInfo().Assembly;
            //var reportingAssembly = typeof(GetAppAdminModel).GetTypeInfo().Assembly;
            //var servicesAssembly = typeof(IMailService).GetTypeInfo().Assembly;

            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(ICommandHandler<>));
            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(ICommandHandlerAsync<>));
            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(IValidator<>));
            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(IRules<>));
            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(IEventHandler<>));
            //builder.RegisterAssemblyTypes(domainAssembly).AsClosedTypesOf(typeof(IEventHandlerAsync<>));

            //builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IRepository<>));
            //builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IEventHandler<>));
            //builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IEventHandlerAsync<>));
            //builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IQueryHandler<,>));
            //builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IQueryHandlerAsync<,>));

            //builder.RegisterAssemblyTypes(reportingAssembly).AsClosedTypesOf(typeof(IEventHandler<>));
            //builder.RegisterAssemblyTypes(reportingAssembly).AsClosedTypesOf(typeof(IEventHandlerAsync<>));

            builder.RegisterAssemblyTypes(infrastructureAssembly).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(domainAssembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(dataAssembly).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(reportingAssembly).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(servicesAssembly).AsImplementedInterfaces();
        }
    }
}
