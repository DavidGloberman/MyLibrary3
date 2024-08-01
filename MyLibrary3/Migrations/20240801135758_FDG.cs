using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary3.Migrations
{
    /// <inheritdoc />
    public partial class FDG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "BookSet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookSet_LibraryId",
                table: "BookSet",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSet_Library_LibraryId",
                table: "BookSet",
                column: "LibraryId",
                principalTable: "Library",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSet_Library_LibraryId",
                table: "BookSet");

            migrationBuilder.DropIndex(
                name: "IX_BookSet_LibraryId",
                table: "BookSet");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "BookSet");
        }
    }
}
