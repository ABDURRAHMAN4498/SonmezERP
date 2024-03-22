using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonmezERP.Migrations
{
    /// <inheritdoc />
    public partial class ProductsAndDetailFristEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitsOfMeasurementName_UnitsOfMeasurementId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UnitsOfMeasurementId",
                table: "Products",
                newName: "UnitsOfMeasurementNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UnitsOfMeasurementId",
                table: "Products",
                newName: "IX_Products_UnitsOfMeasurementNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitsOfMeasurementName_UnitsOfMeasurementNameId",
                table: "Products",
                column: "UnitsOfMeasurementNameId",
                principalTable: "UnitsOfMeasurementName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitsOfMeasurementName_UnitsOfMeasurementNameId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UnitsOfMeasurementNameId",
                table: "Products",
                newName: "UnitsOfMeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UnitsOfMeasurementNameId",
                table: "Products",
                newName: "IX_Products_UnitsOfMeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitsOfMeasurementName_UnitsOfMeasurementId",
                table: "Products",
                column: "UnitsOfMeasurementId",
                principalTable: "UnitsOfMeasurementName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
