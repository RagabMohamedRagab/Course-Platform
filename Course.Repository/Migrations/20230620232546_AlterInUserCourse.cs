using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlterInUserCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "UserCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c025c8a2-a69b-41ed-a810-66bded55ba55");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "986769a3-27cd-4593-8bfa-81d5da2521ea", "AQAAAAEAACcQAAAAEElGvwhSimkLf9X69ShZyPMfq6MXrj25h4awepoCpKe2u50A6YEg29K5h2+wz3Qi/w==", "334d8b50-5829-438c-a699-87095d23e82b" });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_TitleId",
                table: "UserCourses",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Titles_TitleId",
                table: "UserCourses",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Titles_TitleId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_TitleId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "UserCourses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d9c5a489-208b-4981-9157-463d8641ec8b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d90d9f80-3b21-4861-aae1-5d7f8df85835", "AQAAAAEAACcQAAAAEI9mhrGo2pWzQXQeyjBwQcGiKb6jdONHDWDtKtf/yNYO6652NBbrI4cJD2QnhbMXzw==", "9142cdf6-8bfd-45f7-afd0-b5d9b6210f39" });
        }
    }
}
