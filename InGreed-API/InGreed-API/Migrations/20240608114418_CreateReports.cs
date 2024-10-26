using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InGreed_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    opinion_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => new { x.opinion_id, x.user_id });
                });

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumns: new[] { "ingredient_id", "user_id" },
                keyValues: new object[] { 1, 1 },
                column: "preference_type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumns: new[] { "ingredient_id", "user_id" },
                keyValues: new object[] { 2, 1 },
                column: "preference_type",
                value: -1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumns: new[] { "ingredient_id", "user_id" },
                keyValues: new object[] { 1, 1 },
                column: "preference_type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumns: new[] { "ingredient_id", "user_id" },
                keyValues: new object[] { 2, 1 },
                column: "preference_type",
                value: 1);
        }
    }
}
