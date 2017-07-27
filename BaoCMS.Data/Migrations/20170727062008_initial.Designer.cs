using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BaoCMS.Data;

namespace BaoCMS.Data.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20170727062008_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BaoCMS.Data.Entities.DomainAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("DomainAggregate");
                });

            modelBuilder.Entity("BaoCMS.Data.Entities.DomainEvent", b =>
                {
                    b.Property<Guid>("DomainAggregateId");

                    b.Property<int>("SequenceNumber");

                    b.Property<string>("Body");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<string>("Type");

                    b.Property<Guid>("UserId");

                    b.HasKey("DomainAggregateId", "SequenceNumber");

                    b.ToTable("DomainEvent");
                });

            modelBuilder.Entity("BaoCMS.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<Guid>("CreateUserId");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("UpdateDateTime");

                    b.Property<Guid>("UpdateUserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BaoCMS.Data.Entities.DomainEvent", b =>
                {
                    b.HasOne("BaoCMS.Data.Entities.DomainAggregate", "DomainAggregate")
                        .WithMany("DomainEvents")
                        .HasForeignKey("DomainAggregateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
