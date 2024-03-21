using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marketplace.Migrations
{
    /// <inheritdoc />
    public partial class reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItem_Wishlist_WishlistId",
                table: "WishlistItem");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_WishlistItem_WishlistId",
                table: "WishlistItem");

            migrationBuilder.DropColumn(
                name: "WishlistId",
                table: "WishlistItem");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Conquest", 213.0, "Mythical Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Battles", 321.0, "Mystic Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Manor", 257.0, "Mythical Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Conquest", 381.0, "Mystic Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price" },
                values: new object[] { "Mystic Magic", 492.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Manor", 154.0, "Galactic Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "price", "producer" },
                values: new object[] { 908.0, "Mythical Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Battles", 723.0, "Galactic Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Manor", 974.0, "Mystic Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Magic", 432.0, "Galactic Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Magic", 883.0, "Adventure Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Quest", 939.0, "Mystic Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Quest", 559.0, "Empire Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Magic", 867.0, "Galactic Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Conquest", 952.0, "Legendary Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Conquest", 340.0, "Adventure Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Quest", 387.0, "Adventure Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Manor", 637.0, "Legendary Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Battles", 428.0, "Mythical Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Manor", 331.0, "Mythical Studios" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WishlistId",
                table: "WishlistItem",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_user_id = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Magic", 539.0, "Legendary Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Chronicles", 395.0, "Empire Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Quest", 612.0, "Empire Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Manor", 875.0, "Legendary Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price" },
                values: new object[] { "Kingdoms Manor", 493.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Manor", 757.0, "Mythical Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "price", "producer" },
                values: new object[] { 432.0, "Legendary Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Chronicles", 121.0, "Empire Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Quest", 235.0, "Mystic Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Chronicles", 439.0, "Mystic Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Manor", 440.0, "Mystic Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Conquest", 404.0, "Empire Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Quest", 952.0, "Mythical Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Magic", 235.0, "Legendary Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Battles", 945.0, "Mystic Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Conquest", 834.0, "Mystic Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Quest", 857.0, "Mythical Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Quest", 215.0, "Mystic Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Magic", 805.0, "Mythical Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Magic", 213.0, "Empire Entertainment" });

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItem_WishlistId",
                table: "WishlistItem",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_fk_user_id",
                table: "Wishlist",
                column: "fk_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItem_Wishlist_WishlistId",
                table: "WishlistItem",
                column: "WishlistId",
                principalTable: "Wishlist",
                principalColumn: "id");
        }
    }
}
