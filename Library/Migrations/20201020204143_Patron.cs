using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Patron : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AspNetUsers_UserId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_UserId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Books",
                newName: "PatronId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_UserId",
                table: "Books",
                newName: "IX_Books_PatronId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Authors",
                newName: "PatronId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_UserId",
                table: "Authors",
                newName: "IX_Authors_PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AspNetUsers_PatronId",
                table: "Authors",
                column: "PatronId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_PatronId",
                table: "Books",
                column: "PatronId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AspNetUsers_PatronId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_PatronId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PatronId",
                table: "Books",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PatronId",
                table: "Books",
                newName: "IX_Books_UserId");

            migrationBuilder.RenameColumn(
                name: "PatronId",
                table: "Authors",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_PatronId",
                table: "Authors",
                newName: "IX_Authors_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AspNetUsers_UserId",
                table: "Authors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_UserId",
                table: "Books",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
