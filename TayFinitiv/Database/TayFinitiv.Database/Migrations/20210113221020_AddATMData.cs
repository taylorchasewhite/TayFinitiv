using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TayFinitiv.Database.Migrations
{
    public partial class AddATMData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATMs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ones = table.Column<int>(type: "int", nullable: false),
                    Fives = table.Column<int>(type: "int", nullable: false),
                    Tens = table.Column<int>(type: "int", nullable: false),
                    Twenties = table.Column<int>(type: "int", nullable: false),
                    Fifties = table.Column<int>(type: "int", nullable: false),
                    Hundreds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATMs");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
