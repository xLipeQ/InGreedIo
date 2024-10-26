using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InGreed_API.Migrations
{
    /// <inheritdoc />
    public partial class Defaultingredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "id", "icon", "name" },
                values: new object[,]
                {
                    { 1, new byte[0], "Ingredient1" },
                    { 2, new byte[0], "Ingredient2" },
                    { 3, new byte[0], "Ingredient3" },
                    { 4, new byte[0], "Ingredient4" },
                    { 5, new byte[0], "AIngredient" },
                    { 6, new byte[0], "BIngredient" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
