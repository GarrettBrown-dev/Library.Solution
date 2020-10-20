using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class All : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BookCopies_BookCopyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BookCopyId",
                table: "AspNetUsers");

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BookCopyId",
                table: "AspNetUsers",
                column: "BookCopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BookCopies_BookCopyId",
                table: "AspNetUsers",
                column: "BookCopyId",
                principalTable: "BookCopies",
                principalColumn: "BookCopyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
