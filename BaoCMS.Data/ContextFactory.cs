using BaoCMS.Data.Configuration;
using BaoCMS.Framework.Resolver;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaoCMS.Data
{
    public class ContextFactory : IContextFactory
    {
        private Configuration.Data DataConfiguration { get; }
        private ConnectionStrings ConnectionStrings { get; }
        private readonly IResolver _resolver;

        public ContextFactory(IOptions<Configuration.Data> dataOptions,
            IResolver resolver, IOptions<ConnectionStrings> connectionStringsOption)
        {
            DataConfiguration = dataOptions.Value;
            ConnectionStrings = connectionStringsOption.Value;
            _resolver = resolver;
        }

        public DbContext Create()
        {
            var dataProvider = _resolver.ResolveAll<IDataProvider>().SingleOrDefault(x => x.Provider == DataConfiguration.Provider);

            if (dataProvider == null)
                throw new Exception("The Data Provider entry in appsettings.json is empty or the one specified has not been found!");

            return dataProvider.CreateDbContext(ConnectionStrings.DefaultConnection);
        }
    }
}
