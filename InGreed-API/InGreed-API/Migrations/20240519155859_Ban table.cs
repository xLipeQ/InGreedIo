using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InGreed_API.Migrations
{
    /// <inheritdoc />
    public partial class Bantable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    ban_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.ban_id);
                    table.ForeignKey(
                        name: "FK_Bans_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bans",
                columns: new[] { "ban_id", "reason", "user_id" },
                values: new object[] { 1, "Bad behavior", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Bans_user_id",
                table: "Bans",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bans");
        }
    }
}
