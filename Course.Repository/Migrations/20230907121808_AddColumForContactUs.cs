using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddColumForContactUs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ac5537be-8a9c-48fd-93d0-3ecb825480e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad85d980-06e9-4f20-990d-a3411bb175e4", "AQAAAAEAACcQAAAAEN0iSmTe6SWOnkqbIzxPfT/vWNlOzVruO/pmN3JVt53LfNQN5NWQRZRSYHuWMiJlIw==", "da6f9075-3c26-4e7b-86eb-23d537cb1534" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "ContactUs");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "9d06477f-965d-4ab9-82c7-4e9a35b076d6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d24fd11-a404-4a0e-82a1-c45ef4d7b70f", "AQAAAAEAACcQAAAAEN9iKDykxvpQnNA7XioOyxayE0gIj/V7mVg2lWOFBCo7F+JSs6pSCISF7knhY8Mq1g==", "8397216a-a955-482a-bda3-22f241e7db3f" });
        }
    }
}
