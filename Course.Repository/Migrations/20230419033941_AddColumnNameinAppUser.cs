using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnNameinAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8279844-8c78-4c00-af6f-f2667706bd22");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeab029e-1bae-4e00-b085-d2737570c0d3", null, "AQAAAAEAACcQAAAAEGBDZYGPxdW860JScZM2Q9TrZeg3iJJu1d0BH1skkn3kuZQ42+GsvagRpwctInHAIQ==", "4db5757a-bd38-4114-ad87-1e5ce7425151" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a2a19e8f-fa2f-41cb-b262-4ae9e08ffe97");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8279844-8c78-4c00-af6f-f2667706bd22", "be1c42b0-cdf6-4e58-878f-614c072c0b5d", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abe60980-1af9-4659-a633-26cc8dc6abcb", "AQAAAAEAACcQAAAAEFff+WoFo2cRqqgS8LwsFjThUJqNj9cdpeiMa7KQ4LXz3TbcFWEPrHUPO9lrO4q7GQ==", "75c82fd3-3504-4a9b-b148-d8c28a091021" });
        }
    }
}
