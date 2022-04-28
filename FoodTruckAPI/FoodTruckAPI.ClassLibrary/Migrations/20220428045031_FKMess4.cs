using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    public partial class FKMess4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Menus_MenuID",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_MenuID",
                table: "Trucks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trucks_MenuID",
                table: "Trucks",
                column: "MenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Menus_MenuID",
                table: "Trucks",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "MenuID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
