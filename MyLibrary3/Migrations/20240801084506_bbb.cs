using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary3.Migrations
{
    /// <inheritdoc />
    public partial class bbb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSetBooks",
                table: "Book");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsSetBooks",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
