using BaoCMS.Data.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Data
{
    public interface IDataProvider
    {
        DataProvider Provider { get; }
        IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString);
        DbContext CreateDbContext(string connectionString);
    }
}
