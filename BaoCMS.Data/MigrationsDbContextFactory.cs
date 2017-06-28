using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Data
{
    public class MigrationsDbContextFactory : IDbContextFactory<DbContext>
    {
        public DbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<DbContext>();
            builder.UseSqlServer("UsedForMigrationsOnlyUntilClassLibraryBugIsFixed");

            return new DbContext(builder.Options);
        }
    }
}
