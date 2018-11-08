using System;
using System.Collections.Generic;
using System.Text;
using Identity.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.EntityConfigurations
{
    class RoleTypeEntityTypeConfiguration : IEntityTypeConfiguration<RoleType>
    {
        public void Configure(EntityTypeBuilder<RoleType> roleTypeConfiguaration)
        {
            roleTypeConfiguaration.ToTable("roletypes");

            roleTypeConfiguaration.HasKey(o => o.Id);

            roleTypeConfiguaration.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            roleTypeConfiguaration.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
