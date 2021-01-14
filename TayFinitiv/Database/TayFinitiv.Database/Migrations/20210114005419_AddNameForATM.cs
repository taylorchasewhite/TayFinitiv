using Microsoft.EntityFrameworkCore.Migrations;

namespace TayFinitiv.Database.Migrations
{
    public partial class AddNameForATM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ATMs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ATMs");
        }
    }
}
