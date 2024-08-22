using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bangazon.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    Open = table.Column<bool>(type: "boolean", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PaymentId = table.Column<int>(type: "integer", nullable: false),
                    StreetAddress = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Zip = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: true),
                    CardNumber = table.Column<string>(type: "text", nullable: true),
                    Ccv = table.Column<string>(type: "text", nullable: true),
                    Zip = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    SellerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Seller = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "SellerId", "Title" },
                values: new object[,]
                {
                    { 1, "Make a statement with the Zip Up Lapel Braided Belt Denim Mini Dress, perfect for adding a touch of rock-chic to your wardrobe. In a versatile medium denim color, this dress combines classic and edgy elements with a collared neck and zip-up front, giving you a look that's cool and confident. The short sleeves keep it casual, while the braided belt cinches the waist with effortless style.\r\n\r\nFeaturing a braided belt and pockets, this dress blends fashion with function, making it as practical as it is stylish. Whether you're pairing it with boots or sneakers, this imported denim mini dress is designed for those who love a bit of edge without sacrificing sophistication.", "https://shopstageclothing.com/cdn/shop/files/9502F0EE-10E1-4E65-A4FC-A847CC958D64.jpg?v=1723552266&width=713", 55.00m, "1", "Zeppelin Zip Up Mini Dress" },
                    { 2, "YES, it has pockets! Discover the perfect blend of comfort and chic with our Harpeth Flare Mini Skirt. This skirt offers a soft, breathable feel that’s perfect for all-day wear. The flattering flare silhouette adds a playful touch to your outfit, while the mini length keeps it modern and stylish. Plus, again, it has pockets.\r\n\r\nWhether you're heading to brunch, a casual outing, or a night out, this versatile skirt effortlessly transitions from day to night.\r\n\r\nThe Harpeth Flare Mini Skirt pairs beautifully with your favorite tops, from casual tees to glam blouses.", "https://shopstageclothing.com/cdn/shop/files/839A5C78-33D2-4D9A-9BD7-DFB753CF992C.jpg?v=1723552215&width=713", 20.00m, "2", "Harpeth Flare Mini Skirt" },
                    { 3, "A well-loved favorite, featuring a crew neck, short sleeves, and a hand drawn design.\r\n\r\n\r\n\r\nFeatures: Sideseamed. Retail fit. Unisex sizing. Shoulder taping. Preshrunk fabric.\r\n\r\nThis product is made on demand.", "https://shopstageclothing.com/cdn/shop/files/5773dd4b-e96d-4453-82ea-20fe913c5d4b.jpg?v=1704683860&width=713", 25.00m, "2", "Midnight Oil Skeleton Rock Tee" },
                    { 4, "The Southern Earring Set from Shop Stage Clothing is the perfect accessory to complete any outfit. This set of earrings is subtle and intriguing, sure to draw compliments.\r\n\r\nThe earrings are made from high-quality materials and feature unique designs. They are lightweight and comfortable to wear, making them ideal for everyday use. Whether you're dressing up for a special occasion or just want to add a touch of style to your everyday look, these earrings are the perfect choice.", "https://shopstageclothing.com/cdn/shop/files/THESOUTHERNEARRINGSET.jpg?v=1695945185&width=713", 5.00m, "1", "The Southern Earring Set" },
                    { 5, "With a tie neck AND tie back, the halter holds all of the versatility that you need. Pair with leather, pair with denim, pair with whatever! It’s super soft fabric is a plus on top of everything else!", "https://shopstageclothing.com/cdn/shop/files/IMG-6779.heic?v=1724009646&width=713", 20.00m, "1", "Fairyland Dainty Halter Top" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Seller" },
                values: new object[,]
                {
                    { "1", "felicia_mings@yahoo.com", "Felicia", "Yahoo", false },
                    { "2", "felicia.mings13@gmail.com", "Lola", "Gmail", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "ProductItems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
