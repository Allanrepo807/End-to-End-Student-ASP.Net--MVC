using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WApp.Migrations
{
    /// <inheritdoc />
    public partial class Addedtheyeartothestudenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Students");
        }
    }
}
