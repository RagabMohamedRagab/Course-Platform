using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlterAddeedingDataforUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "a47f4b9d-ceb9-4aad-8662-5255ed714207");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Logo", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fdb4e8dc-6660-42be-951f-3513e65734f1", null, 0, "a0e708d7-3daf-4d26-ac64-50070fe5ea55", "AppUser", "Admin123@gmail.com", true, true, null, null, "ADMIN123@GMAIL.COM", "ADMIN123@GMAIL.COM", "AQAAAAEAACcQAAAAEJxgo6CpgWBmmxVUBz2MZ3VIbycSJFemxRz2gIGIff44g2zvlDJrrozV1JDAI18OiQ==", null, true, "eaf0a2e6-e618-41e8-af5f-be7e6a093bc4", false, "Admin123@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fdb4e8dc-6660-42be-951f-3513e65734f1");

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
    }
}
