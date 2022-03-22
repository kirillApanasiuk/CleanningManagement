using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanningManagement.Infrastructure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CleanningPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleanningPlans", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CleanningPlans",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Description", "Title" },
                values: new object[] { new Guid("183eef1f-e4eb-489d-bd3d-720443bce7c2"), new DateTime(2022, 3, 22, 11, 10, 30, 941, DateTimeKind.Local).AddTicks(8577), 1, "Simple cleanning plan", "Simple" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleanningPlans");
        }
    }
}
