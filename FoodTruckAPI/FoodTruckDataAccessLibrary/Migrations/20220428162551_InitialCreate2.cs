using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Menu3",
                table: "Menus",
                newName: "Main3");

            migrationBuilder.RenameColumn(
                name: "Menu2",
                table: "Menus",
                newName: "Main2");

            migrationBuilder.RenameColumn(
                name: "Menu1",
                table: "Menus",
                newName: "Main1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Main3",
                table: "Menus",
                newName: "Menu3");

            migrationBuilder.RenameColumn(
                name: "Main2",
                table: "Menus",
                newName: "Menu2");

            migrationBuilder.RenameColumn(
                name: "Main1",
                table: "Menus",
                newName: "Menu1");
        }
    }
}
