using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "side2",
                table: "Menus",
                newName: "Side2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Side2",
                table: "Menus",
                newName: "side2");
        }
    }
}
