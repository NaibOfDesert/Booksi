using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booksi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrderFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderData_OrderId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order",
                newName: "OrderDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderId",
                table: "Order",
                newName: "IX_Order_OrderDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderData_OrderDataId",
                table: "Order",
                column: "OrderDataId",
                principalTable: "OrderData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderData_OrderDataId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderDataId",
                table: "Order",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderDataId",
                table: "Order",
                newName: "IX_Order_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderData_OrderId",
                table: "Order",
                column: "OrderId",
                principalTable: "OrderData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
