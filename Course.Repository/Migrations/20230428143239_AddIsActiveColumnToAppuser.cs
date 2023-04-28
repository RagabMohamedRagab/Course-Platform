using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveColumnToAppuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8c13a53a-4c78-4810-aa9d-3ee4a483dbc7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "760d984c-59d2-4b9d-b700-2f171aca6554", false, "AQAAAAEAACcQAAAAEH9DWZQbDPo4taVx0SH/V/QEvkj0gWz6NlI1CcfAf7VugQwXakyF77WhxJAQ7fzh1g==", "3946dd27-4788-4e0e-a597-54d19e390ecd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2a92ed7a-ace9-4a20-8a38-ea7f29904ec6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59cbb62e-70dc-4a26-b7d1-caf606ed4057", "AQAAAAEAACcQAAAAEBzdgW6gpf11ZEnJwG+Nt3VGFjQ+a4vjCRZ5aHATXrNYtp1mZu43cAyrYlGrtYQfrQ==", "16a6d820-b371-4f98-afe6-5520a63f21c4" });
        }
    }
}
