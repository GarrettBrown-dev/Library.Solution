using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class BookId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopy_Books_BookId",
                table: "BookCopy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCopy",
                table: "BookCopy");

            migrationBuilder.RenameTable(
                name: "BookCopy",
                newName: "BookCopies");

            migrationBuilder.RenameIndex(
                name: "IX_BookCopy_BookId",
                table: "BookCopies",
                newName: "IX_BookCopies_BookId");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BookCopies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCopies",
                table: "BookCopies",
                column: "BookCopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_Books_BookId",
                table: "BookCopies",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_Books_BookId",
                table: "BookCopies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCopies",
                table: "BookCopies");

            migrationBuilder.RenameTable(
                name: "BookCopies",
                newName: "BookCopy");

            migrationBuilder.RenameIndex(
                name: "IX_BookCopies_BookId",
                table: "BookCopy",
                newName: "IX_BookCopy_BookId");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BookCopy",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCopy",
                table: "BookCopy",
                column: "BookCopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopy_Books_BookId",
                table: "BookCopy",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
