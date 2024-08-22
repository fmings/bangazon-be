﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bangazon;

#nullable disable

namespace bangazon.Migrations
{
    [DbContext(typeof(BangazonDBContext))]
    [Migration("20240822004813_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("bangazon.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Open")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("bangazon.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("bangazon.Models.PaymentDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNumber")
                        .HasColumnType("text");

                    b.Property<string>("Ccv")
                        .HasColumnType("text");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("PaymentType")
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("bangazon.Models.ProductItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("SellerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Make a statement with the Zip Up Lapel Braided Belt Denim Mini Dress, perfect for adding a touch of rock-chic to your wardrobe. In a versatile medium denim color, this dress combines classic and edgy elements with a collared neck and zip-up front, giving you a look that's cool and confident. The short sleeves keep it casual, while the braided belt cinches the waist with effortless style.\r\n\r\nFeaturing a braided belt and pockets, this dress blends fashion with function, making it as practical as it is stylish. Whether you're pairing it with boots or sneakers, this imported denim mini dress is designed for those who love a bit of edge without sacrificing sophistication.",
                            ImageUrl = "https://shopstageclothing.com/cdn/shop/files/9502F0EE-10E1-4E65-A4FC-A847CC958D64.jpg?v=1723552266&width=713",
                            Price = 55.00m,
                            SellerId = "1",
                            Title = "Zeppelin Zip Up Mini Dress"
                        },
                        new
                        {
                            Id = 2,
                            Description = "YES, it has pockets! Discover the perfect blend of comfort and chic with our Harpeth Flare Mini Skirt. This skirt offers a soft, breathable feel that’s perfect for all-day wear. The flattering flare silhouette adds a playful touch to your outfit, while the mini length keeps it modern and stylish. Plus, again, it has pockets.\r\n\r\nWhether you're heading to brunch, a casual outing, or a night out, this versatile skirt effortlessly transitions from day to night.\r\n\r\nThe Harpeth Flare Mini Skirt pairs beautifully with your favorite tops, from casual tees to glam blouses.",
                            ImageUrl = "https://shopstageclothing.com/cdn/shop/files/839A5C78-33D2-4D9A-9BD7-DFB753CF992C.jpg?v=1723552215&width=713",
                            Price = 20.00m,
                            SellerId = "2",
                            Title = "Harpeth Flare Mini Skirt"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A well-loved favorite, featuring a crew neck, short sleeves, and a hand drawn design.\r\n\r\n\r\n\r\nFeatures: Sideseamed. Retail fit. Unisex sizing. Shoulder taping. Preshrunk fabric.\r\n\r\nThis product is made on demand.",
                            ImageUrl = "https://shopstageclothing.com/cdn/shop/files/5773dd4b-e96d-4453-82ea-20fe913c5d4b.jpg?v=1704683860&width=713",
                            Price = 25.00m,
                            SellerId = "2",
                            Title = "Midnight Oil Skeleton Rock Tee"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The Southern Earring Set from Shop Stage Clothing is the perfect accessory to complete any outfit. This set of earrings is subtle and intriguing, sure to draw compliments.\r\n\r\nThe earrings are made from high-quality materials and feature unique designs. They are lightweight and comfortable to wear, making them ideal for everyday use. Whether you're dressing up for a special occasion or just want to add a touch of style to your everyday look, these earrings are the perfect choice.",
                            ImageUrl = "https://shopstageclothing.com/cdn/shop/files/THESOUTHERNEARRINGSET.jpg?v=1695945185&width=713",
                            Price = 5.00m,
                            SellerId = "1",
                            Title = "The Southern Earring Set"
                        },
                        new
                        {
                            Id = 5,
                            Description = "With a tie neck AND tie back, the halter holds all of the versatility that you need. Pair with leather, pair with denim, pair with whatever! It’s super soft fabric is a plus on top of everything else!",
                            ImageUrl = "https://shopstageclothing.com/cdn/shop/files/IMG-6779.heic?v=1724009646&width=713",
                            Price = 20.00m,
                            SellerId = "1",
                            Title = "Fairyland Dainty Halter Top"
                        });
                });

            modelBuilder.Entity("bangazon.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Seller")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Email = "felicia_mings@yahoo.com",
                            FirstName = "Felicia",
                            LastName = "Yahoo",
                            Seller = false
                        },
                        new
                        {
                            Id = "2",
                            Email = "felicia.mings13@gmail.com",
                            FirstName = "Lola",
                            LastName = "Gmail",
                            Seller = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
