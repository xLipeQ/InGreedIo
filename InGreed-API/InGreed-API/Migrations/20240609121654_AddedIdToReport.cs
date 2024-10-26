using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InGreed_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdToReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Reports",
                newName: "reporter_id");

            migrationBuilder.RenameColumn(
                name: "opinion_id",
                table: "Reports",
                newName: "product_id");

            migrationBuilder.AddColumn<int>(
                name: "opinion_creator_id",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "opinion_creator_id",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "reporter_id",
                table: "Reports",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Reports",
                newName: "opinion_id");
        }
    }
}
