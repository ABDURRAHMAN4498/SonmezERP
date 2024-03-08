using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonmezERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCrearte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductNameTr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceTl = table.Column<float>(type: "real", nullable: false),
                    PriceUSD = table.Column<float>(type: "real", nullable: false),
                    ProductWidth = table.Column<int>(type: "int", nullable: false),
                    ProductHight = table.Column<int>(type: "int", nullable: false),
                    ProductSize = table.Column<int>(type: "int", nullable: false),
                    ProductWeight = table.Column<float>(type: "real", nullable: false),
                    PackageWidth = table.Column<int>(type: "int", nullable: false),
                    PackageSize = table.Column<int>(type: "int", nullable: false),
                    PackageHight = table.Column<int>(type: "int", nullable: false),
                    PackagePices = table.Column<int>(type: "int", nullable: false),
                    CubicMeter = table.Column<float>(type: "real", nullable: false),
                    Tir = table.Column<int>(type: "int", nullable: false),
                    Container = table.Column<int>(type: "int", nullable: false),
                    Coordinate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
