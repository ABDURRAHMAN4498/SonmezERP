using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonmezERP.Migrations
{
    /// <inheritdoc />
    public partial class Product_Inputs_Log_Create_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductInputLogList_ProductId",
                table: "ProductInputLogList",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInputLogList_Products_ProductId",
                table: "ProductInputLogList",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInputLogList_Products_ProductId",
                table: "ProductInputLogList");

            migrationBuilder.DropIndex(
                name: "IX_ProductInputLogList_ProductId",
                table: "ProductInputLogList");
        }
    }
}
