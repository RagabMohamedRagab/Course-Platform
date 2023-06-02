using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlterInCourseTableAndTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Titles",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8b375cc7-dea9-4f7d-9bc8-21c72cf295f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbf6c83d-5bb2-4e0c-a20c-2390bf25b784", "AQAAAAEAACcQAAAAENwQvYKDMBOgOTonS4Ca4wwaG/E3IVewWADSRRDOoGtp7X1Fd1raCrVhvEVLyirL8w==", "c444d877-f17d-45c9-8293-f33556c4848c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Titles");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "25bb28d1-f40e-4b3c-ab95-a87a1f7b7117");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7e959ff-0f77-45d1-9dd9-014b72a3d443", "AQAAAAEAACcQAAAAEFvNXzpxMFxR4wa1/RUbfkbVQzuDU9O1Id0FVpeuYAeyL5BO3E7NJle7xoA9i595Fg==", "62c821f6-2780-4317-8304-862a01165bfc" });
        }
    }
}
