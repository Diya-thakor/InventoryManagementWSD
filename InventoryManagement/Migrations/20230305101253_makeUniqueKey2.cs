using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    public partial class makeUniqueKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name_OrganizationId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name_OrganizationId",
                table: "Products",
                columns: new[] { "Name", "OrganizationId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name_OrganizationId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name_OrganizationId",
                table: "Products",
                columns: new[] { "Name", "OrganizationId" });
        }
    }
}
