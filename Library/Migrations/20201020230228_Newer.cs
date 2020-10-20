using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Newer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_AspNetUsers_PatronId1",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_PatronId1",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "PatronId1",
                table: "Checkouts");

            migrationBuilder.AlterColumn<string>(
                name: "PatronId",
                table: "Checkouts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_PatronId",
                table: "Checkouts",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_AspNetUsers_PatronId",
                table: "Checkouts",
                column: "PatronId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_AspNetUsers_PatronId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_PatronId",
                table: "Checkouts");

            migrationBuilder.AlterColumn<int>(
                name: "PatronId",
                table: "Checkouts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatronId1",
                table: "Checkouts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_PatronId1",
                table: "Checkouts",
                column: "PatronId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_AspNetUsers_PatronId1",
                table: "Checkouts",
                column: "PatronId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
