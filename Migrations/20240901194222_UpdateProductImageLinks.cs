using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bangazon.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductImageLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://shopstageclothing.com/cdn/shop/files/9502F0EE-10E1-4E65-A4FC-A847CC958D64.jpg?v=1723552266&width=360");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://shopstageclothing.com/cdn/shop/files/839A5C78-33D2-4D9A-9BD7-DFB753CF992C.jpg?v=1723552215&width=360");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://shopstageclothing.com/cdn/shop/files/4dab356a-0af4-46c7-8a0d-ce627dbead25.jpg?v=1724598715&width=360");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://shopstageclothing.com/cdn/shop/files/THESOUTHERNEARRINGSET.jpg?v=1724599446&width=360");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://shopstageclothing.com/cdn/shop/files/IMG-6779.heic?v=1724598933&width=360");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://shopstageclothing.com/cdn/shop/files/9502F0EE-10E1-4E65-A4FC-A847CC958D64.jpg?v=1723552266&width=713");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://shopstageclothing.com/cdn/shop/files/839A5C78-33D2-4D9A-9BD7-DFB753CF992C.jpg?v=1723552215&width=713");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://shopstageclothing.com/cdn/shop/files/5773dd4b-e96d-4453-82ea-20fe913c5d4b.jpg?v=1704683860&width=713");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://shopstageclothing.com/cdn/shop/files/THESOUTHERNEARRINGSET.jpg?v=1695945185&width=713");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://shopstageclothing.com/cdn/shop/files/IMG-6779.heic?v=1724009646&width=713");
        }
    }
}
