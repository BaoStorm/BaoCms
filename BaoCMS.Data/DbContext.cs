using BaoCMS.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DomainAggregate>()
                .ToTable("DomainAggregate");

            builder.Entity<DomainEvent>()
                .ToTable("DomainEvent")
                .HasKey(x => new { x.DomainAggregateId, x.SequenceNumber });

            builder.Entity<User>()
                .ToTable("User");

        }




        public DbSet<DomainAggregate> DomainAggregates { get; set; }
        public DbSet<DomainEvent> DomainEvents { get; set; }
        public DbSet<User> Users { set; get; }
    }
}
