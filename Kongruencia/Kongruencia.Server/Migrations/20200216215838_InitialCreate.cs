using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kongruencia.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coverages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Metrics_statements = table.Column<int>(nullable: true),
                    Metrics_coveredstatements = table.Column<int>(nullable: true),
                    Metrics_conditionals = table.Column<int>(nullable: true),
                    Metrics_coveredconditionals = table.Column<int>(nullable: true),
                    Metrics_methods = table.Column<int>(nullable: true),
                    Metrics_coveredmethods = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    BuildNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coverages");
        }
    }
}
