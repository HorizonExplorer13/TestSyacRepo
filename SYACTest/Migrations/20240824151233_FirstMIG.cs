using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SYACTest.Migrations
{
    public partial class FirstMIG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    clientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.clientId);
                });

            migrationBuilder.CreateTable(
                name: "purchesOrders",
                columns: table => new
                {
                    purchesOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientId = table.Column<int>(type: "int", nullable: false),
                    recordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TtotalToPurch = table.Column<int>(type: "int", nullable: false),
                    totalPurchValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchesOrders", x => x.purchesOrderId);
                    table.ForeignKey(
                        name: "FK_purchesOrders_clients_clientId",
                        column: x => x.clientId,
                        principalTable: "clients",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productUnitValue = table.Column<int>(type: "int", nullable: false),
                    purchesOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_purchesOrders_purchesOrderId",
                        column: x => x.purchesOrderId,
                        principalTable: "purchesOrders",
                        principalColumn: "purchesOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsToPurchs",
                columns: table => new
                {
                    productsToPurchsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    purchesOrderId = table.Column<int>(type: "int", nullable: false),
                    TtotalToPurch = table.Column<int>(type: "int", nullable: false),
                    totalPurchValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsToPurchs", x => x.productsToPurchsId);
                    table.ForeignKey(
                        name: "FK_ProductsToPurchs_purchesOrders_purchesOrderId",
                        column: x => x.purchesOrderId,
                        principalTable: "purchesOrders",
                        principalColumn: "purchesOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_purchesOrderId",
                table: "Products",
                column: "purchesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsToPurchs_purchesOrderId",
                table: "ProductsToPurchs",
                column: "purchesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_purchesOrders_clientId",
                table: "purchesOrders",
                column: "clientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductsToPurchs");

            migrationBuilder.DropTable(
                name: "purchesOrders");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
