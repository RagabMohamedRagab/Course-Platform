using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "33cb16e3-6e38-4a2e-88cd-70ed8dce4731");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49fd02fa-c020-4bc5-a11c-ec941a3b0660", "AQAAAAEAACcQAAAAEKurZHcKdqapI3zS8AZogRssDE3yXi8DJ751L4jbXs7Wmb6SyhexH8STRyv7umAZ7g==", "c26f195c-494d-412d-9708-c908ee95e35d" });
        }
    }
}
