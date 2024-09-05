using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SYACTest.Migrations
{
    public partial class FirstMIGPostTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_purchesOrders_purchesOrderId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductsToPurchs");

            migrationBuilder.DropIndex(
                name: "IX_Products_purchesOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RequestAddress",
                table: "purchesOrders");

            migrationBuilder.DropColumn(
                name: "TtotalToPurch",
                table: "purchesOrders");

            migrationBuilder.DropColumn(
                name: "totalPurchValue",
                table: "purchesOrders");

            migrationBuilder.DropColumn(
                name: "productoCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "purchesOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "address",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "document",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "name",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "purchesOrderId",
                table: "purchesOrders",
                newName: "purchesOrderid");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "Products",
                newName: "productname");

            migrationBuilder.RenameColumn(
                name: "productUnitValue",
                table: "Products",
                newName: "unitValue");

            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "purchesOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "priority",
                table: "purchesOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "purchesOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "deliveryAddress",
                table: "purchesOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "productname",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "productCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "clientAddress",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "clientDocument",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "clientName",
                table: "clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "orderProducts",
                columns: table => new
                {
                    orderProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    purchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    partialValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderProducts", x => x.orderProductId);
                    table.ForeignKey(
                        name: "FK_orderProducts_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderProducts_purchesOrders_purchaseOrderId",
                        column: x => x.purchaseOrderId,
                        principalTable: "purchesOrders",
                        principalColumn: "purchesOrderid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderProducts_productId",
                table: "orderProducts",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_orderProducts_purchaseOrderId",
                table: "orderProducts",
                column: "purchaseOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderProducts");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "purchesOrders");

            migrationBuilder.DropColumn(
                name: "deliveryAddress",
                table: "purchesOrders");

            migrationBuilder.DropColumn(
                name: "productCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "clientAddress",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "clientDocument",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "clientName",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "purchesOrderid",
                table: "purchesOrders",
                newName: "purchesOrderId");

            migrationBuilder.RenameColumn(
                name: "productname",
                table: "Products",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "unitValue",
                table: "Products",
                newName: "productUnitValue");

            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "purchesOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "priority",
                table: "purchesOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestAddress",
                table: "purchesOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TtotalToPurch",
                table: "purchesOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalPurchValue",
                table: "purchesOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "productoCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "purchesOrderId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "document",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_purchesOrders_purchesOrderId",
                table: "Products",
                column: "purchesOrderId",
                principalTable: "purchesOrders",
                principalColumn: "purchesOrderId");
        }
    }
}
