using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    public partial class FKMess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuMenuID",
                table: "Trucks",
                newName: "MenuID");

            migrationBuilder.RenameColumn(
                name: "MenuMenuID",
                table: "MenuItemLinks",
                newName: "MenuItemID");

            migrationBuilder.RenameColumn(
                name: "MenuItemMenuItemID",
                table: "MenuItemLinks",
                newName: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "Trucks",
                newName: "MenuMenuID");

            migrationBuilder.RenameColumn(
                name: "MenuItemID",
                table: "MenuItemLinks",
                newName: "MenuMenuID");

            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "MenuItemLinks",
                newName: "MenuItemMenuItemID");
        }
    }
}
