using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class DAddeedingDataforUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "6b04250d-e6d0-4db9-a096-7df0b68e29b8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Logo", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "60768616-1e39-49a2-8004-29549846ff12", null, 0, "65513950-3927-4d0f-b1c9-7c4d3f20a199", "AppUser", "Admin123@gmail.com", true, false, null, null, "ADMIN123@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEPBNjaqNwqA+fXpekhEdK3IwDiKgqFmjsKFDAPfplgQ3ZMUjLXTVRr2tIc3+wWFJtw==", null, false, "2106f7b8-6d99-492b-aa77-840a121eab18", false, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60768616-1e39-49a2-8004-29549846ff12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "da9afda3-3ede-4d00-b555-9ebd741026e7");
        }
    }
}
