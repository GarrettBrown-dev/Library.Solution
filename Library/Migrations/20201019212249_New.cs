using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatalogCount",
                table: "Catalogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatalogCount",
                table: "Catalogs");
        }
    }
}
