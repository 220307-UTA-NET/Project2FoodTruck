using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    public partial class FKMess3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemLinks_MenuItems_MenuItemID",
                table: "MenuItemLinks");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemLinks_MenuItemID",
                table: "MenuItemLinks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
