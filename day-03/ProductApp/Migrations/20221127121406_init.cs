using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "...")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "/images/products/default.jpg"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "..."),
                    AtCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Bilgisayar", "..." },
                    { 2, "SmartPhone", "..." },
                    { 3, "Electronic", "..." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AtCreated", "Description", "ImageUrl", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 27, 15, 14, 6, 59, DateTimeKind.Local).AddTicks(3080), "HP Laptop Touch your Dreams", "/images/products/1.jpg", 15000m, "HP Z Book" },
                    { 2, new DateTime(2022, 11, 27, 15, 14, 6, 59, DateTimeKind.Local).AddTicks(3096), "Airpods for your ears", "/images/products/2.jpg", 5000m, "AirPods" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AtCreated", "Price", "ProductName" },
                values: new object[] { 3, new DateTime(2022, 11, 27, 15, 14, 6, 59, DateTimeKind.Local).AddTicks(3098), 7000m, "Samsun Galaxy Note FE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
