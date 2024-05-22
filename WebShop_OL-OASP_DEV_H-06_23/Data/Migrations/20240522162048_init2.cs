using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_OL_OASP_DEV_H_06_23.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2024, 5, 22, 18, 20, 47, 190, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2024, 5, 22, 18, 20, 47, 190, DateTimeKind.Local).AddTicks(4862));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2024, 5, 10, 20, 26, 42, 588, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2024, 5, 10, 20, 26, 42, 588, DateTimeKind.Local).AddTicks(5071));
        }
    }
}
