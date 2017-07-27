using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaoCMS.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomainAggregate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainAggregate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DomainEvent",
                columns: table => new
                {
                    DomainAggregateId = table.Column<Guid>(nullable: false),
                    SequenceNumber = table.Column<int>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainEvent", x => new { x.DomainAggregateId, x.SequenceNumber });
                    table.ForeignKey(
                        name: "FK_DomainEvent_DomainAggregate_DomainAggregateId",
                        column: x => x.DomainAggregateId,
                        principalTable: "DomainAggregate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomainEvent");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "DomainAggregate");
        }
    }
}
