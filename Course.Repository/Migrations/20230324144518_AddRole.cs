using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1a362f7c-f104-4aef-965f-3e8bc398eaec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32ab264d-bfb3-4819-8400-eeeaa068cfe1", "115a4291-ee19-4a0a-87f1-03a4fc46b5cc", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bf5d160-8a75-46a9-8be8-888c85966bfc", "AQAAAAEAACcQAAAAEB1S/P9SX5/dcg5HNHfFWwp7Q+oME1kuzpg7SGMoL84qAHDkrkmPL6eNdGsb6Js4Zw==", "f8e631ff-148e-4317-bf3d-90fd0a108e4b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32ab264d-bfb3-4819-8400-eeeaa068cfe1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "49937824-1fd6-4abf-b11a-8c9940510bde");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14b93a45-0556-4123-8105-00fb5dfc3caf", "AQAAAAEAACcQAAAAEKBIocCsEmJki9xMRLK+IjLrOmBDvJwgpsdgQ4h5X22NBrJh5SD4gcfsxlAaD25UlA==", "59532a9a-928a-44b4-af99-434e24b93738" });
        }
    }
}
