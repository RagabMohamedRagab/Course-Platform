using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlterInTitleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c155836d-46d8-43ea-a8f0-56436467d897");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e9213d6-6b38-4b2f-b40c-071ac17d4dcb", "AQAAAAEAACcQAAAAEOsjA8vLzTnmNaMLxa1yq50k5KiXzjdl8b7EC2MSSe3L6hYalPeexldirXWxoUXiEQ==", "641e81df-c498-4a0a-8474-a54297a0d698" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "34132d19-5a09-4b5a-a841-14c71ad34cc1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a09faa99-de26-47fa-8551-bf562b3eb977", "AQAAAAEAACcQAAAAEBXRBECvIhduhTvucwJEzyJalBIgn5CWiEMEN/I81/kEMNkY8gwuk7FI3hP6oQFLiA==", "c7f47239-28be-41c1-b605-032cd621df9a" });
        }
    }
}
