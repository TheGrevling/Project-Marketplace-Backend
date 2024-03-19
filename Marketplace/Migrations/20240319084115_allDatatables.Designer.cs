﻿// <auto-generated />
using System;
using Marketplace.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marketplace.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240319084115_allDatatables")]
    partial class allDatatables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Marketplace.DataModels.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Marketplace.DataModels.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Marketplace.DataModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderHistoryId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_order_history_id");

                    b.Property<int>("OrderItemId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_order_item_id");

                    b.Property<int>("OrderQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<double>("OrderSum")
                        .HasColumnType("double precision")
                        .HasColumnName("sum");

                    b.HasKey("Id");

                    b.HasIndex("OrderHistoryId");

                    b.HasIndex("OrderItemId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Marketplace.DataModels.OrderHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_order_id");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("shipping_address");

                    b.Property<string>("ShippingCity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("shipping_city");

                    b.Property<string>("ShippingPostCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("shipping_postcode");

                    b.Property<double>("TotalSum")
                        .HasColumnType("double precision")
                        .HasColumnName("total_sum");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fk_user_id");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderHistory");
                });

            modelBuilder.Entity("Marketplace.DataModels.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_product_id");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Marketplace.DataModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("integer")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imageURL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("producer");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = 0,
                            Description = "Description of boardgame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg",
                            Name = "Galactic Magic",
                            Price = 424.0,
                            Producer = "Empire Games"
                        },
                        new
                        {
                            Id = 2,
                            Category = 0,
                            Description = "Description of boardgame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg",
                            Name = "Epic Manor",
                            Price = 213.0,
                            Producer = "Legendary Productions"
                        },
                        new
                        {
                            Id = 3,
                            Category = 0,
                            Description = "Description of boardgame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg",
                            Name = "Mystic Battles",
                            Price = 214.0,
                            Producer = "Mythical Studios"
                        },
                        new
                        {
                            Id = 4,
                            Category = 0,
                            Description = "Description of boardgame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg",
                            Name = "Kingdoms Manor",
                            Price = 591.0,
                            Producer = "Empire Entertainment"
                        },
                        new
                        {
                            Id = 5,
                            Category = 0,
                            Description = "Description of boardgame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg",
                            Name = "Ancient Manor",
                            Price = 291.0,
                            Producer = "Mythical Productions"
                        },
                        new
                        {
                            Id = 6,
                            Category = 1,
                            Description = "Description of cardgame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg",
                            Name = "Adventure Battles",
                            Price = 798.0,
                            Producer = "Adventure Creations"
                        },
                        new
                        {
                            Id = 7,
                            Category = 1,
                            Description = "Description of cardgame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg",
                            Name = "Adventure Battles",
                            Price = 984.0,
                            Producer = "Legendary Games"
                        },
                        new
                        {
                            Id = 8,
                            Category = 1,
                            Description = "Description of cardgame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg",
                            Name = "Adventure Chronicles",
                            Price = 715.0,
                            Producer = "Galactic Co."
                        },
                        new
                        {
                            Id = 9,
                            Category = 1,
                            Description = "Description of cardgame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg",
                            Name = "Adventure Quest",
                            Price = 812.0,
                            Producer = "Mystic Productions"
                        },
                        new
                        {
                            Id = 10,
                            Category = 1,
                            Description = "Description of cardgame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg",
                            Name = "Galactic Conquest",
                            Price = 315.0,
                            Producer = "Adventure Creations"
                        },
                        new
                        {
                            Id = 11,
                            Category = 2,
                            Description = "Description of roleplay",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg",
                            Name = "Epic Conquest",
                            Price = 456.0,
                            Producer = "Mystic Creations"
                        },
                        new
                        {
                            Id = 12,
                            Category = 2,
                            Description = "Description of roleplay",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg",
                            Name = "Galactic Manor",
                            Price = 471.0,
                            Producer = "Empire Creations"
                        },
                        new
                        {
                            Id = 13,
                            Category = 2,
                            Description = "Description of roleplay",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg",
                            Name = "Galactic Magic",
                            Price = 324.0,
                            Producer = "Empire Co."
                        },
                        new
                        {
                            Id = 14,
                            Category = 2,
                            Description = "Description of roleplay",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg",
                            Name = "Epic Conquest",
                            Price = 659.0,
                            Producer = "Mythical Productions"
                        },
                        new
                        {
                            Id = 15,
                            Category = 2,
                            Description = "Description of roleplay",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg",
                            Name = "Epic Conquest",
                            Price = 626.0,
                            Producer = "Mystic Co."
                        },
                        new
                        {
                            Id = 16,
                            Category = 3,
                            Description = "Description of puzzlegame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg",
                            Name = "Adventure Manor",
                            Price = 467.0,
                            Producer = "Galactic Co."
                        },
                        new
                        {
                            Id = 17,
                            Category = 3,
                            Description = "Description of puzzlegame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg",
                            Name = "Ancient Quest",
                            Price = 161.0,
                            Producer = "Empire Creations"
                        },
                        new
                        {
                            Id = 18,
                            Category = 3,
                            Description = "Description of puzzlegame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg",
                            Name = "Mystic Chronicles",
                            Price = 451.0,
                            Producer = "Legendary Productions"
                        },
                        new
                        {
                            Id = 19,
                            Category = 3,
                            Description = "Description of puzzlegame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg",
                            Name = "Kingdoms Conquest",
                            Price = 659.0,
                            Producer = "Galactic Studios"
                        },
                        new
                        {
                            Id = 20,
                            Category = 3,
                            Description = "Description of puzzlegame",
                            ImageURL = "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg",
                            Name = "Ancient Magic",
                            Price = 239.0,
                            Producer = "Adventure Studios"
                        });
                });

            modelBuilder.Entity("Marketplace.DataModels.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_product_id");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Marketplace.DataModels.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fk_user_id");

                    b.Property<int>("WishlistItemId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_wishlist_item_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WishlistItemId");

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("Marketplace.DataModels.WishlistItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_product_id");

                    b.Property<int>("WishlistId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_wishlist_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WishlistId");

                    b.ToTable("WishlistItem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Marketplace.DataModels.Inventory", b =>
                {
                    b.HasOne("Marketplace.DataModels.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Marketplace.DataModels.Order", b =>
                {
                    b.HasOne("Marketplace.DataModels.OrderHistory", "OrderHistory")
                        .WithMany()
                        .HasForeignKey("OrderHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketplace.DataModels.OrderItem", "OrderItem")
                        .WithMany()
                        .HasForeignKey("OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHistory");

                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("Marketplace.DataModels.OrderHistory", b =>
                {
                    b.HasOne("Marketplace.DataModels.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Marketplace.DataModels.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Marketplace.DataModels.OrderItem", b =>
                {
                    b.HasOne("Marketplace.DataModels.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketplace.DataModels.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Marketplace.DataModels.Review", b =>
                {
                    b.HasOne("Marketplace.DataModels.Product", "Product")
                        .WithMany("reviewsList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketplace.DataModels.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Marketplace.DataModels.Wishlist", b =>
                {
                    b.HasOne("Marketplace.DataModels.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketplace.DataModels.WishlistItem", "WishlistItem")
                        .WithMany()
                        .HasForeignKey("WishlistItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("WishlistItem");
                });

            modelBuilder.Entity("Marketplace.DataModels.WishlistItem", b =>
                {
                    b.HasOne("Marketplace.DataModels.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketplace.DataModels.Wishlist", "Wishlist")
                        .WithMany()
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Marketplace.DataModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Marketplace.DataModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Marketplace.DataModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Marketplace.DataModels.Product", b =>
                {
                    b.Navigation("reviewsList");
                });
#pragma warning restore 612, 618
        }
    }
}
