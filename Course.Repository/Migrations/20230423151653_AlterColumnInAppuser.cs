using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnInAppuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Profile",
                table: "AspNetUsers",
                newName: "LinkedIn");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "03a56607-0fd8-4a00-b75d-1fedb7f315dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "575eafc7-8830-4b51-803b-b361ce2d351a", "AQAAAAEAACcQAAAAEIEpNHGThFcTyVK90n6K3/aJQDfLqMBoQlWh2ulWZQOnDrOb1bVtj1K5ZTec+1pK0g==", "209530ef-897d-4030-809b-8fabed9d0e7b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkedIn",
                table: "AspNetUsers",
                newName: "Profile");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c880d1ac-7bd5-48af-9b4d-2100c5b4a864");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeab029e-1bae-4e00-b085-d2737570c0d3", "AQAAAAEAACcQAAAAEGBDZYGPxdW860JScZM2Q9TrZeg3iJJu1d0BH1skkn3kuZQ42+GsvagRpwctInHAIQ==", "4db5757a-bd38-4114-ad87-1e5ce7425151" });
        }
    }
}
