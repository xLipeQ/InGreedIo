using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InGreed_API.Migrations
{
    /// <inheritdoc />
    public partial class Createimagetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "image_id", "image", "product_id" },
                values: new object[,]
                {
                    { 1, new byte[0], 1 },
                    { 2, new byte[0], 2 },
                    { 3, new byte[0], 3 },
                    { 4, new byte[0], 4 },
                    { 5, new byte[0], 5 },
                    { 6, new byte[0], 6 },
                    { 7, new byte[0], 7 },
                    { 8, new byte[0], 8 },
                    { 9, new byte[0], 9 },
                    { 10, new byte[0], 10 },
                    { 11, new byte[0], 11 },
                    { 12, new byte[0], 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_product_id",
                table: "ProductImages",
                column: "product_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "Products",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 1,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 2,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 3,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 4,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 5,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 6,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 7,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 8,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 9,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 10,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 11,
                column: "image",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 12,
                column: "image",
                value: new byte[0]);
        }
    }
}
