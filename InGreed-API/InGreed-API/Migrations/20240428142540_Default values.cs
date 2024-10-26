using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InGreed_API.Migrations
{
    /// <inheritdoc />
    public partial class Defaultvalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "ingredient_id", "user_id", "preference_type" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "id", "category_id", "product_id" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductIngredients",
                columns: new[] { "id", "ingredient_id", "product_id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 13, 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 1,
                column: "producent_id",
                value: 3);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "product_id", "description", "image", "product_name", "producent_id" },
                values: new object[,]
                {
                    { 2, "Very good shampoo", new byte[0], "Premium Shampoo N2", 3 },
                    { 3, "Very good shampoo", new byte[0], "Premium Shampoo N3", 3 },
                    { 4, "Very good shampoo", new byte[0], "Premium Shampoo N4", 3 },
                    { 5, "Very good shampoo", new byte[0], "Premium Shampoo N5", 3 },
                    { 6, "Very good shampoo", new byte[0], "Premium Shampoo N6", 3 },
                    { 7, "Very good shampoo", new byte[0], "Premium Shampoo N7", 3 },
                    { 8, "Very good shampoo", new byte[0], "Premium Shampoo N8", 3 },
                    { 9, "Very good shampoo", new byte[0], "Premium Shampoo N9", 3 },
                    { 10, "Very good shampoo", new byte[0], "Premium Shampoo N10", 3 },
                    { 11, "Very good shampoo", new byte[0], "Premium Shampoo N11", 3 },
                    { 12, "Very good shampoo", new byte[0], "Premium Shampoo N12", 3 }
                });

            migrationBuilder.InsertData(
                table: "FavouriteProducts",
                columns: new[] { "product_id", "user_id" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Opinions",
                columns: new[] { "product_id", "user_id", "comment", "rating" },
                values: new object[,]
                {
                    { 2, 1, "Useful product", 5 },
                    { 2, 2, "Awful product", 1 },
                    { 3, 1, "Decent product", 4 }
                });

            migrationBuilder.InsertData(
                table: "ProductIngredients",
                columns: new[] { "id", "ingredient_id", "product_id" },
                values: new object[,]
                {
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 1, 6 },
                    { 7, 1, 7 },
                    { 8, 1, 8 },
                    { 9, 1, 9 },
                    { 10, 1, 10 },
                    { 11, 1, 11 },
                    { 12, 1, 12 }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "id", "end", "product_id", "start" },
                values: new object[,]
                {
                    { 1, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FavouriteProducts",
                keyColumns: new[] { "product_id", "user_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumns: new[] { "product_id", "user_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumns: new[] { "product_id", "user_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumns: new[] { "product_id", "user_id" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumns: new[] { "ingredient_id", "user_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumns: new[] { "ingredient_id", "user_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductIngredients",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 1,
                column: "producent_id",
                value: 2);
        }
    }
}
