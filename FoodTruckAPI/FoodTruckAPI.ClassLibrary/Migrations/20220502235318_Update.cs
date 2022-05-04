using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTruckLinks_Trucks_TruckID",
                table: "EmployeeTruckLinks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTruckLinks_TruckID",
                table: "EmployeeTruckLinks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTruckLinks_TruckID",
                table: "EmployeeTruckLinks",
                column: "TruckID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTruckLinks_Trucks_TruckID",
                table: "EmployeeTruckLinks",
                column: "TruckID",
                principalTable: "Trucks",
                principalColumn: "TruckID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
