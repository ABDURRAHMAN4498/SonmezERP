using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SonmezERP.Migrations
{
    /// <inheritdoc />
    public partial class IdenitityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a573c55-7a1e-452e-8b81-504be27b2316", null, "Editor", "EDITOR" },
                    { "ce482d16-c156-42ee-8ea2-62ec6adf1045", null, "Admin", "ADMIN" },
                    { "d41231e4-5492-467b-9340-258710461d70", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a573c55-7a1e-452e-8b81-504be27b2316");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce482d16-c156-42ee-8ea2-62ec6adf1045");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d41231e4-5492-467b-9340-258710461d70");
        }
    }
}
