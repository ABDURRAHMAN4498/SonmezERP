using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonmezERP.Migrations
{
    /// <inheritdoc />
    public partial class UnitsOfMeasurementNametoUnitsOfMeasurement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitsOfMeasurementName_UnitsOfMeasurementNameId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitsOfMeasurementName",
                table: "UnitsOfMeasurementName");

            migrationBuilder.RenameTable(
                name: "UnitsOfMeasurementName",
                newName: "UnitsOfMeasurements");

            migrationBuilder.RenameColumn(
                name: "UnitsOfMeasurementNameId",
                table: "Products",
                newName: "UnitsOfMeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UnitsOfMeasurementNameId",
                table: "Products",
                newName: "IX_Products_UnitsOfMeasurementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitsOfMeasurements",
                table: "UnitsOfMeasurements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitsOfMeasurements_UnitsOfMeasurementId",
                table: "Products",
                column: "UnitsOfMeasurementId",
                principalTable: "UnitsOfMeasurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitsOfMeasurements_UnitsOfMeasurementId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitsOfMeasurements",
                table: "UnitsOfMeasurements");

            migrationBuilder.RenameTable(
                name: "UnitsOfMeasurements",
                newName: "UnitsOfMeasurementName");

            migrationBuilder.RenameColumn(
                name: "UnitsOfMeasurementId",
                table: "Products",
                newName: "UnitsOfMeasurementNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UnitsOfMeasurementId",
                table: "Products",
                newName: "IX_Products_UnitsOfMeasurementNameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitsOfMeasurementName",
                table: "UnitsOfMeasurementName",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitsOfMeasurementName_UnitsOfMeasurementNameId",
                table: "Products",
                column: "UnitsOfMeasurementNameId",
                principalTable: "UnitsOfMeasurementName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
