using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InGreed_API.Migrations
{
    /// <inheritdoc />
    public partial class Opinionidcolumndeletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id",
                table: "Opinions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Opinions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
