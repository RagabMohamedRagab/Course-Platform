using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddCoverInBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8ca350c3-801b-485e-bc9c-5fdfd777c3c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b61f0b5-cd2b-4fb2-a1dd-d67a2584936e", "AQAAAAEAACcQAAAAEP0RHUgTI3hDZUKGh7d5GznukzcBoXSvSjD7Qi1MjV6TJXYhq8UKGyBu3bT2b6NZSg==", "76ec9565-a3d9-4ba8-b4fd-e4c6dab049e2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "0047cc4c-debc-4bf4-acde-c99a99b66f15");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b81cd014-965a-4c60-a777-61562b49caf3", "AQAAAAEAACcQAAAAEDlcUJHvLcPW0I7PnO4Y0E1OqFRTNEDjr44t/v57gzud68a3oRPMEo3AcfudRZyVyg==", "7b601475-302f-4158-bd4d-fb12e7466995" });
        }
    }
}
