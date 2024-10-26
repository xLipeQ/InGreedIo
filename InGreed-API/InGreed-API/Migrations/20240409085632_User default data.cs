using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InGreed_API.Migrations
{
    /// <inheritdoc />
    public partial class Userdefaultdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email_notifications", "mail", "password_hash", "role", "username" },
                values: new object[,]
                {
                    { 1, true, "clientingreed@gmail.com", "AQAAAAIAAYagAAAAECFziXNCSrKgVQUGu4Ius9In7O1dytR+XOgViy8cOrwqdwj6zcjrRJOBS/vPAPJjZg==", 3, "client" },
                    { 2, false, "clientingreed2@gmail.com", "AQAAAAIAAYagAAAAEFMl2ibmxljVgSYUvel1WmE+iB7IbRjl8QeWhf1fA0bhaR0TSaGEwETnWj2z/SjbfA==", 3, "client2" },
                    { 3, true, "producent@gmail.com", "AQAAAAIAAYagAAAAEMzfRediqiZFTiV6Xpz38DYmSUDq3j5hmqbaaTbBrbLVWThkHKG508Iznr/bca8uWg==", 2, "producent" },
                    { 4, false, "producentingreed2@gmail.com", "AQAAAAIAAYagAAAAEIFvpaWPRcE+iakhC6p4hHrmq0EOmt3id7vIPU3iMZjNM7aTuAJVsv3yxtLzgG1KHQ==", 2, "producent2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
