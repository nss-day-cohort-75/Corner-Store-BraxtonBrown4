﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CornerStore.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CashierId = table.Column<int>(type: "integer", nullable: false),
                    PaidOnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cashiers_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Cashiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cashiers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Alice", "Smith" },
                    { 2, "Bob", "Johnson" },
                    { 3, "Charlie", "Williams" },
                    { 4, "David", "Brown" },
                    { 5, "Eve", "Davis" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Home Goods" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CashierId", "PaidOnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1320) },
                    { 2, 2, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1400) },
                    { 3, 3, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1400) },
                    { 4, 4, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1410) },
                    { 5, 5, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1410) },
                    { 6, 1, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1410) },
                    { 7, 2, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1420) },
                    { 8, 3, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1420) },
                    { 9, 4, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1420) },
                    { 10, 5, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1420) },
                    { 11, 1, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1430) },
                    { 12, 2, new DateTime(2025, 5, 16, 10, 10, 58, 865, DateTimeKind.Local).AddTicks(1430) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "Generic", 1, 1200.00m, "Laptop" },
                    { 2, "Generic", 1, 800.00m, "Smartphone" },
                    { 3, "Generic", 2, 25.00m, "T-Shirt" },
                    { 4, "Generic", 2, 75.00m, "Jeans" },
                    { 5, "Generic", 3, 60.00m, "Coffee Maker" },
                    { 6, "Generic", 3, 45.00m, "Blender" },
                    { 7, "Generic", 1, 300.00m, "Tablet" },
                    { 8, "Generic", 2, 120.00m, "Jacket" },
                    { 9, "Generic", 3, 30.00m, "Toaster" },
                    { 10, "Generic", 1, 150.00m, "Headphones" }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 2 },
                    { 3, 2, 3, 3 },
                    { 4, 2, 4, 4 },
                    { 5, 3, 5, 5 },
                    { 6, 3, 6, 6 },
                    { 7, 4, 7, 7 },
                    { 8, 4, 8, 8 },
                    { 9, 5, 9, 9 },
                    { 10, 5, 10, 10 },
                    { 11, 6, 1, 1 },
                    { 12, 6, 3, 2 },
                    { 13, 7, 5, 3 },
                    { 14, 7, 7, 4 },
                    { 15, 8, 9, 5 },
                    { 16, 8, 2, 6 },
                    { 17, 9, 4, 7 },
                    { 18, 9, 6, 8 },
                    { 19, 10, 8, 9 },
                    { 20, 10, 10, 10 },
                    { 21, 11, 2, 1 },
                    { 22, 11, 4, 2 },
                    { 23, 12, 6, 3 },
                    { 24, 12, 8, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CashierId",
                table: "Orders",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
