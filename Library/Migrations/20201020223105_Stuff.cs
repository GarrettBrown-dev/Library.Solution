using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Stuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatronId",
                table: "BookCopies",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_PatronId",
                table: "BookCopies",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_AspNetUsers_PatronId",
                table: "BookCopies",
                column: "PatronId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_AspNetUsers_PatronId",
                table: "BookCopies");

            migrationBuilder.DropIndex(
                name: "IX_BookCopies_PatronId",
                table: "BookCopies");

            migrationBuilder.DropColumn(
                name: "PatronId",
                table: "BookCopies");

            migrationBuilder.DropColumn(
                name: "BookCopyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PatronId",
                table: "AspNetUsers");
        }
    }
}
