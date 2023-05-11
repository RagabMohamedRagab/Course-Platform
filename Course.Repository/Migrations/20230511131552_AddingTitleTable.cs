using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddingTitleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d4d5a6b3-2547-4f4e-8419-f29e500d8a56");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fe03736-ef34-456a-a433-41e69ad1ffbe", "AQAAAAEAACcQAAAAEGd5biyxWlpLL0Dn5kYvsN9IUBvzQBBMyC5iuINXwAT9HypUKoQvUjm9oV0KJD6RKA==", "c11322d9-b799-4c01-bb3c-01d7eb838ef3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
