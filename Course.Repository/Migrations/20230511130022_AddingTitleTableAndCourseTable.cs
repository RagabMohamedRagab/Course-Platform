using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddingTitleTableAndCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "fe2a98c1-fb81-460a-a44d-d65e66195cbb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b607500-c0af-43f8-b3ad-1e235e084f12", "AQAAAAEAACcQAAAAEKsQfNMmyVFoc7qQ4c2LoOAY9hhd4IGSKz4lZikJLi/LRGm2wEeY1nw1JNfobZjN8w==", "044b02c8-668d-4f1b-92e7-029fe1cb4bca" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e1b0b8e8-f1ab-4a1a-a33a-7026ea47ba11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78f1350f-142e-4c59-9ba7-a6a0c8e4e8d8", "AQAAAAEAACcQAAAAEBjMxXBM9YRC69vflxEgRJKt4hS1m1XAkk8OVK+cS9N9Dl473QPYDxDGBUI5O1cEgQ==", "55ae7b32-2f01-41e7-8f32-2d52495d8045" });
        }
    }
}
