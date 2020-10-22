using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class New2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCopyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PatronId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCopyId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatronId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
