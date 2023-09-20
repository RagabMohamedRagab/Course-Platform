using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlterInCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "a87aa740-e3f1-444b-af02-a3ccfd713986");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90fa38a2-280a-4b15-8eda-934e5dea6063", "AQAAAAEAACcQAAAAEBEkqCnckxvT5doDhLt3IWSEBiwexFCrotgszs5unOhifAxzrwphNpPiQPRcFj1Dtg==", "ebde87d8-5fbc-483d-b531-9a71637a13b5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutId",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d8faf080-2941-4e1b-a9b0-74f8212761ed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31e85bb0-29fe-42cc-8c2c-b1b73946d09b", "AQAAAAEAACcQAAAAEMOagEkzRcWtmc8JvVyaIdgZvm7P0qX3m7RTFxrRt5FIZcg5J+R8s67qQuAGFrHAIA==", "c7aa652a-9fca-4f77-9438-56c24da49c7b" });
        }
    }
}
