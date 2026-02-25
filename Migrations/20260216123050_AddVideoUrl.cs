using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillaAgency.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-5555-5555-5555-000000000001"),
                column: "VideoUrl",
                value: "https://www.youtube.com/watch?v=7HKq20ihNAU");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "SiteSettings");
        }
    }
}
