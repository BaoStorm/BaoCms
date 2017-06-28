using BaoCMS.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Data.Providers
{
    public class PostgreSQLDataProvider : IDataProvider
    {
        public DataProvider Provider { get; } = DataProvider.PostgreSQL;

        public IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }

        public DbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new DbContext(optionsBuilder.Options);
        }
    }
}
