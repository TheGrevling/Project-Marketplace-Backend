using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Migrations
{
    /// <inheritdoc />
    public partial class reviewses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_user_id",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Review",
                newName: "user_name");

            migrationBuilder.RenameIndex(
                name: "IX_Review_user_id",
                table: "Review",
                newName: "IX_Review_user_name");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Manor", 629.0, "Galactic Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Battles", 423.0, "Adventure Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Battles", 284.0, "Mythical Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Battles", 407.0, "Adventure Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Chronicles", 436.0, "Empire Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Battles", 909.0, "Galactic Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Chronicles", 847.0, "Galactic Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Magic", 737.0, "Legendary Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Conquest", 800.0, "Galactic Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Battles", 745.0, "Mystic Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Manor", 784.0, "Galactic Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Battles", 352.0, "Adventure Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Conquest", 564.0, "Legendary Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Manor", 221.0, "Mythical Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Manor", 647.0, "Galactic Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "name", "price" },
                values: new object[] { "Galactic Conquest", 934.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Conquest", 735.0, "Galactic Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Conquest", 543.0, "Empire Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Conquest", 372.0, "Legendary Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Quest", 238.0, "Empire Co." });

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_user_name",
                table: "Review",
                column: "user_name",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_user_name",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "Review",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Review_user_name",
                table: "Review",
                newName: "IX_Review_user_id");

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
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Magic", 492.0, "Mythical Games" });

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
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Quest", 908.0, "Mythical Studios" });

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
                columns: new[] { "name", "price" },
                values: new object[] { "Ancient Conquest", 340.0 });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_user_id",
                table: "Review",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
