using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary3.Migrations
{
    /// <inheritdoc />
    public partial class FD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "BookSet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "BookSet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
