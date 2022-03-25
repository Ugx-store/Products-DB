using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class ProductDBMigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Products",
                newName: "Town");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Products",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Town",
                table: "Products",
                newName: "Location");
        }
    }
}
