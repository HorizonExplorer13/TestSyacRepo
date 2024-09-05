using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SYACTest.Migrations
{
    public partial class secondMIG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_purchesOrders_purchesOrderId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "purchesOrderId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_purchesOrders_purchesOrderId",
                table: "Products",
                column: "purchesOrderId",
                principalTable: "purchesOrders",
                principalColumn: "purchesOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_purchesOrders_purchesOrderId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "purchesOrderId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_purchesOrders_purchesOrderId",
                table: "Products",
                column: "purchesOrderId",
                principalTable: "purchesOrders",
                principalColumn: "purchesOrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
