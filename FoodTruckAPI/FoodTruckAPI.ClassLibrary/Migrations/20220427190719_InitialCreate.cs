using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTruckAPI.ClassLibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Main1ID = table.Column<int>(type: "int", nullable: false),
                    Main2ID = table.Column<int>(type: "int", nullable: false),
                    Main3ID = table.Column<int>(type: "int", nullable: false),
                    Drink1ID = table.Column<int>(type: "int", nullable: false),
                    Drink2ID = table.Column<int>(type: "int", nullable: false),
                    Side1ID = table.Column<int>(type: "int", nullable: false),
                    Side2ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Menus_MenuItems_Drink1ID",
                        column: x => x.Drink1ID,
                        principalTable: "MenuItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_MenuItems_Drink2ID",
                        column: x => x.Drink2ID,
                        principalTable: "MenuItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_MenuItems_Main1ID",
                        column: x => x.Main1ID,
                        principalTable: "MenuItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_MenuItems_Main2ID",
                        column: x => x.Main2ID,
                        principalTable: "MenuItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_MenuItems_Main3ID",
                        column: x => x.Main3ID,
                        principalTable: "MenuItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_MenuItems_Side1ID",
                        column: x => x.Side1ID,
                        principalTable: "MenuItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_MenuItems_Side2ID",
                        column: x => x.Side2ID,
                        principalTable: "MenuItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    menuID = table.Column<int>(type: "int", nullable: false),
                    Emp1ID = table.Column<int>(type: "int", nullable: false),
                    Emp2ID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trucks_Employees_Emp1ID",
                        column: x => x.Emp1ID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trucks_Employees_Emp2ID",
                        column: x => x.Emp2ID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trucks_Menus_menuID",
                        column: x => x.menuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Drink1ID",
                table: "Menus",
                column: "Drink1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Drink2ID",
                table: "Menus",
                column: "Drink2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Main1ID",
                table: "Menus",
                column: "Main1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Main2ID",
                table: "Menus",
                column: "Main2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Main3ID",
                table: "Menus",
                column: "Main3ID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Side1ID",
                table: "Menus",
                column: "Side1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Side2ID",
                table: "Menus",
                column: "Side2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_Emp1ID",
                table: "Trucks",
                column: "Emp1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_Emp2ID",
                table: "Trucks",
                column: "Emp2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_menuID",
                table: "Trucks",
                column: "menuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
