using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marketplace.Migrations
{
    /// <inheritdoc />
    public partial class allDatatables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    fk_product_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_fk_product_id",
                        column: x => x.fk_product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_order_item_id = table.Column<int>(type: "integer", nullable: false),
                    sum = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    fk_order_history_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shipping_address = table.Column<string>(type: "text", nullable: false),
                    shipping_city = table.Column<string>(type: "text", nullable: false),
                    shipping_postcode = table.Column<string>(type: "text", nullable: false),
                    total_sum = table.Column<double>(type: "double precision", nullable: false),
                    fk_user_id = table.Column<string>(type: "text", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    fk_order_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderHistory_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderHistory_Order_fk_order_id",
                        column: x => x.fk_order_id,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_product_id = table.Column<int>(type: "integer", nullable: false),
                    fk_order_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_fk_order_id",
                        column: x => x.fk_order_id,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_fk_product_id",
                        column: x => x.fk_product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_user_id = table.Column<string>(type: "text", nullable: false),
                    fk_wishlist_item_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.id);
                    table.ForeignKey(
                        name: "FK_Wishlist_AspNetUsers_fk_user_id",
                        column: x => x.fk_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_product_id = table.Column<int>(type: "integer", nullable: false),
                    fk_wishlist_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_WishlistItem_Product_fk_product_id",
                        column: x => x.fk_product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistItem_Wishlist_fk_wishlist_id",
                        column: x => x.fk_wishlist_id,
                        principalTable: "Wishlist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Magic", 424.0, "Empire Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Manor", 213.0, "Legendary Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Battles", 214.0, "Mythical Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Manor", 591.0, "Empire Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Manor", 291.0, "Mythical Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Battles", 798.0, "Adventure Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Battles", 984.0, "Legendary Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Chronicles", 715.0, "Galactic Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Quest", 812.0, "Mystic Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Conquest", 315.0, "Adventure Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "price", "producer" },
                values: new object[] { 456.0, "Mystic Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Manor", 471.0, "Empire Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Magic", 324.0, "Empire Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Conquest", 659.0, "Mythical Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Conquest", 626.0, "Mystic Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Manor", 467.0, "Galactic Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Quest", 161.0, "Empire Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Chronicles", 451.0, "Legendary Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Conquest", 659.0, "Galactic Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Magic", 239.0, "Adventure Studios" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_fk_product_id",
                table: "Inventory",
                column: "fk_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_fk_order_history_id",
                table: "Order",
                column: "fk_order_history_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_fk_order_item_id",
                table: "Order",
                column: "fk_order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_ApplicationUserId",
                table: "OrderHistory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_fk_order_id",
                table: "OrderHistory",
                column: "fk_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_fk_order_id",
                table: "OrderItem",
                column: "fk_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_fk_product_id",
                table: "OrderItem",
                column: "fk_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_fk_user_id",
                table: "Wishlist",
                column: "fk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_fk_wishlist_item_id",
                table: "Wishlist",
                column: "fk_wishlist_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItem_fk_product_id",
                table: "WishlistItem",
                column: "fk_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItem_fk_wishlist_id",
                table: "WishlistItem",
                column: "fk_wishlist_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderHistory_fk_order_history_id",
                table: "Order",
                column: "fk_order_history_id",
                principalTable: "OrderHistory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderItem_fk_order_item_id",
                table: "Order",
                column: "fk_order_item_id",
                principalTable: "OrderItem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_WishlistItem_fk_wishlist_item_id",
                table: "Wishlist",
                column: "fk_wishlist_item_id",
                principalTable: "WishlistItem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderHistory_fk_order_history_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderItem_fk_order_item_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_WishlistItem_fk_wishlist_item_id",
                table: "Wishlist");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "OrderHistory");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "WishlistItem");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Battles", 408.0, "Galactic Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Conquest", 329.0, "Mystic Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Manor", 762.0, "Legendary Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Conquest", 338.0, "Galactic Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Manor", 275.0, "Empire Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Quest", 809.0, "Adventure Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Manor", 307.0, "Galactic Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Battles", 523.0, "Adventure Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Magic", 568.0, "Legendary Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Magic", 736.0, "Mythical Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "price", "producer" },
                values: new object[] { 554.0, "Mystic Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Manor", 526.0, "Mythical Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Quest", 998.0, "Adventure Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Battles", 264.0, "Empire Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Manor", 928.0, "Empire Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Battles", 989.0, "Mystic Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Battles", 277.0, "Galactic Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Conquest", 948.0, "Mythical Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Chronicles", 730.0, "Adventure Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Chronicles", 217.0, "Mythical Co." });
        }
    }
}
