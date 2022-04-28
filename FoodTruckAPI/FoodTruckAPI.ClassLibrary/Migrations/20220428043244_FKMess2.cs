using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    public partial class FKMess2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trucks_MenuID",
                table: "Trucks",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemLinks_MenuID",
                table: "MenuItemLinks",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemLinks_MenuItemID",
                table: "MenuItemLinks",
                column: "MenuItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemLinks_MenuItems_MenuItemID",
                table: "MenuItemLinks",
                column: "MenuItemID",
                principalTable: "MenuItems",
                principalColumn: "MenuItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemLinks_Menus_MenuID",
                table: "MenuItemLinks",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "MenuID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Menus_MenuID",
                table: "Trucks",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "MenuID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemLinks_MenuItems_MenuItemID",
                table: "MenuItemLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemLinks_Menus_MenuID",
                table: "MenuItemLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Menus_MenuID",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_MenuID",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemLinks_MenuID",
                table: "MenuItemLinks");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemLinks_MenuItemID",
                table: "MenuItemLinks");
        }
    }
}
