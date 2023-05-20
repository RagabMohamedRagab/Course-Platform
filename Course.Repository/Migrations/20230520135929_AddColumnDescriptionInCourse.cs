using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnDescriptionInCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f4275eca-255d-460d-a146-edb8ac28068e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "142c3d05-018f-432e-b477-cbbc82494b56", "AQAAAAEAACcQAAAAEK/yfUzGVImhAErCtjmgaNTpfbdulMcUZ7UeVzHUDqHNIEaRbjU0SuQZHVEXSKXiiA==", "cc054f47-4a01-4025-b4d8-de0b6ba033e6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2af21ba6-ea9e-4bbf-88c7-1afa50e8e821");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3df9f37c-7d4a-4273-b241-68854d4bbbf1", "AQAAAAEAACcQAAAAEHLaXqFcZffu46ZUtzHlZPrU4UmctRR2TUpLC7s9115guwa0J12TgALfoZHi4y3vzQ==", "d3777b05-1414-4eb7-8392-0f2022b33189" });
        }
    }
}
