using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TayFinitiv.Database.Migrations
{
    public partial class ClearEverythingBeforeReAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATMs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATMs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fifties = table.Column<int>(type: "int", nullable: false),
                    Fives = table.Column<int>(type: "int", nullable: false),
                    Hundreds = table.Column<int>(type: "int", nullable: false),
                    Ones = table.Column<int>(type: "int", nullable: false),
                    Tens = table.Column<int>(type: "int", nullable: false),
                    Twenties = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMs", x => x.Id);
                });
        }
    }
}
