using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Alter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8b787e00-9f78-42e5-906e-8dfb71d06d80");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72f5d7a8-697e-40b1-8cda-c68d492068c1", "AQAAAAEAACcQAAAAENAfb1/du49+Lb0SIrVMPcCdrd/V+MCp+2iwvnLxL3yruTJPg3sm2a+ykF/S5pmlhQ==", "09dbaa28-742a-41e2-9bfa-576ab5f89df7" });
        }
    }
}
