using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TayFinitiv.Database.Migrations
{
    public partial class AddEverythingBack : Migration
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

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestInstant = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DenominationRequested = table.Column<int>(type: "int", nullable: false),
                    AmountRequested = table.Column<int>(type: "int", nullable: false),
                    WasSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    MessageToUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.Sql("Insert into ATMs (Id, Ones,Fives,Tens,Twenties,Fifties,Hundreds) VALUES ('1',10,10,10,10,10,10)");

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
