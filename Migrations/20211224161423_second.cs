using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehousemanagement.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expirydate",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Expirydate",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
