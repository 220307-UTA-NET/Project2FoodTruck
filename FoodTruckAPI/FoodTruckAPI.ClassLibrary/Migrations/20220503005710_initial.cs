using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "foodtruck");

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "foodtruck",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                schema: "foodtruck",
                columns: table => new
                {
                    MenuItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                schema: "foodtruck",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuID);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                schema: "foodtruck",
                columns: table => new
                {
                    TruckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.TruckID);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemLinks",
                schema: "foodtruck",
                columns: table => new
                {
                    MenuItemLinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    MenuItemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemLinks", x => x.MenuItemLinkID);
                    table.ForeignKey(
                        name: "FK_MenuItemLinks_Menus_MenuID",
                        column: x => x.MenuID,
                        principalSchema: "foodtruck",
                        principalTable: "Menus",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTruckLinks",
                schema: "foodtruck",
                columns: table => new
                {
                    EmployeeTruckLinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    TruckID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTruckLinks", x => x.EmployeeTruckLinkID);
                    table.ForeignKey(
                        name: "FK_EmployeeTruckLinks_Trucks_TruckID",
                        column: x => x.TruckID,
                        principalSchema: "foodtruck",
                        principalTable: "Trucks",
                        principalColumn: "TruckID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTruckLinks_TruckID",
                schema: "foodtruck",
                table: "EmployeeTruckLinks",
                column: "TruckID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemLinks_MenuID",
                schema: "foodtruck",
                table: "MenuItemLinks",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees",
                schema: "foodtruck");

            migrationBuilder.DropTable(
                name: "EmployeeTruckLinks",
                schema: "foodtruck");

            migrationBuilder.DropTable(
                name: "MenuItemLinks",
                schema: "foodtruck");

            migrationBuilder.DropTable(
                name: "MenuItems",
                schema: "foodtruck");

            migrationBuilder.DropTable(
                name: "Trucks",
                schema: "foodtruck");

            migrationBuilder.DropTable(
                name: "Menus",
                schema: "foodtruck");
        }
    }
}
