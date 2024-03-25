using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonmezERP.Migrations
{
    /// <inheritdoc />
    public partial class BrandsAddDescraption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descraption",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descraption",
                table: "Brands");
        }
    }
}
