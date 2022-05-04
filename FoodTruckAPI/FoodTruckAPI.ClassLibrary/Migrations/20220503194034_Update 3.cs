using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeTruckLinks_TruckID",
                schema: "foodtruck",
                table: "EmployeeTruckLinks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTruckLinks_TruckID",
                schema: "foodtruck",
                table: "EmployeeTruckLinks",
                column: "TruckID");
        }
    }
}
