using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlterInTitleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Titles",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Titles_AppUserId",
                table: "Titles",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_AspNetUsers_AppUserId",
                table: "Titles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete:ReferentialAction.NoAction,
                onUpdate:ReferentialAction.NoAction
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_AspNetUsers_AppUserId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_AppUserId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Titles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c3f4dec1-536e-4d25-9500-781a08e4cbd8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27c366aa-c682-49a7-8036-57dc43802598", "AQAAAAEAACcQAAAAELZsDdcIySHgmd8E7NmVtkl8x638WZ9sd6Z/nmclwiIdZkj+zxgLI4zOO7mbdZ2bdQ==", "f429d150-e063-4980-b42f-992a3964440e" });
        }
    }
}
