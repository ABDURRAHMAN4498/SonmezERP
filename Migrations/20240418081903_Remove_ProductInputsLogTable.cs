using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonmezERP.Migrations
{
    /// <inheritdoc />
    public partial class Remove_ProductInputsLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            

            

            

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductInputId",
                table: "ProductInputLogList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductInputLogId",
                table: "ProductInputLogList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProducInputLogs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActionDate",
                table: "ProducInputLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProducInputLogs",
                table: "ProducInputLogs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInputLogList_ProductInputLogId",
                table: "ProductInputLogList",
                column: "ProductInputLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInputLogList_ProducInputLogs_ProductInputLogId",
                table: "ProductInputLogList",
                column: "ProductInputLogId",
                principalTable: "ProducInputLogs",
                principalColumn: "Id");
        }
    }
}
