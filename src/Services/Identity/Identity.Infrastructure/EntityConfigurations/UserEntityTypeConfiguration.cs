using System;
using System.Collections.Generic;
using System.Text;
using Identity.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.EntityConfigurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userConfiguaration)
        {
            userConfiguaration.ToTable("users", IdentityContext.DEFAULT_SCHEMA);

            userConfiguaration.HasKey(o => o.Id);

            userConfiguaration.Ignore(b => b.DomainEvents);

            //userConfiguaration.Property(o => o.Id)
            //    .ForSqlServerUseSequenceHiLo("orderseq", IdentityContext.DEFAULT_SCHEMA);

            userConfiguaration.Property<string>("Name").IsRequired();
            userConfiguaration.Property<string>("Password").IsRequired();
            userConfiguaration.Property<string>("Email").IsRequired();
            userConfiguaration.Property<int>("RoleTypeId").IsRequired();

            userConfiguaration.HasOne(o => o.RoleType)
                .WithMany()
                .HasForeignKey("RoleTypeId");
        }
    }
}
