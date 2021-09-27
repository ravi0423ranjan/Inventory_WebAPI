using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemCode", "ItemName", "ItemPrice" },
                values: new object[] { 1, "VBN", "VBN", 25 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemCode", "ItemName", "ItemPrice" },
                values: new object[] { 2, "CDN", "CDN", 26 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);
        }
    }
}
