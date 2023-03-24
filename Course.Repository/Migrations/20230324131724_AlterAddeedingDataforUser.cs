using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlterAddeedingDataforUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "6a7a5770-7de7-4a78-9f0f-13f53d6a23e1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Logo", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eade758d-30c3-4559-81e3-a6a9f1fe4ec2", null, 0, "b8d488f4-62fb-4a4f-9d29-2c079cfb809a", "AppUser", "Admin123@gmail.com", true, true, null, null, "ADMIN123@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEFfEa36Fh1Pb4Bei4JiK2/7DPlIil3ANcrYBcS6CZ7f7pKmV3bu0XO5ohthtGV7QUA==", null, true, "2bf0f5c2-7e35-4458-a92a-7edcb7f9cbc2", false, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eade758d-30c3-4559-81e3-a6a9f1fe4ec2");

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
    }
}
