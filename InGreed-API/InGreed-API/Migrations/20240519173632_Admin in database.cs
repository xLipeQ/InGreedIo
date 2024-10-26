using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InGreed_API.Migrations
{
    /// <inheritdoc />
    public partial class Adminindatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email_notifications", "mail", "password_hash", "role", "username" },
                values: new object[] { 5, false, "admin@gmail.com", "AQAAAAIAAYagAAAAECFziXNCSrKgVQUGu4Ius9In7O1dytR+XOgViy8cOrwqdwj6zcjrRJOBS/vPAPJjZg==", 0, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
