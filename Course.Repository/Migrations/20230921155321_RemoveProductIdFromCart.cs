using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProductIdFromCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutId",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "848cade4-4c8c-47c1-b3cf-91e31311b5ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2379dad7-4a49-4674-99a2-11f8656411d8", "AQAAAAEAACcQAAAAEAOed0F1RwlyXmGV5i03jr/aLbWRbjw3jti8m5wwDVkvS0bKMhDogx2WnXb4vWyFNA==", "ec726283-8ed3-4d01-8aa4-0485250593c1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a5bb482d-918e-4af2-a2a1-f407202dab01");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d821926-6060-4ac8-8152-7a294c05df8f", "AQAAAAEAACcQAAAAEEZVpjaMsNkzuy8FQKs/B7PYKl/9g+4s3/9q4aTV1caoPJp8Ib74NwuaozBvwdIxwA==", "1342b1dc-f18a-4721-8b03-3e97aeef9e89" });
        }
    }
}
