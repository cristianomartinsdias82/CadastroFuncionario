using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Infrastructure.Persistence.Ef.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    FullName = table.Column<string>(type: "varchar(80)", nullable: false),
                    Ssn = table.Column<string>(type: "varchar(15)", nullable: false),
                    Dob = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
