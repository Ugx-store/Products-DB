using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class ProductDBMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "OriginalPrice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "MarketPrice",
                table: "Products",
                newName: "ItemPrice");

            migrationBuilder.RenameColumn(
                name: "Info",
                table: "Products",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FreeDelivery",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FreeDelivery",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OriginalPrice",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ItemPrice",
                table: "Products",
                newName: "MarketPrice");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Info");
        }
    }
}
