using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Migrations
{
    /// <inheritdoc />
    public partial class reviewnouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_user_name",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_user_name",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "Review");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Conquest", 552.0, "Empire Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Magic", 293.0, "Galactic Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Magic", 807.0, "Legendary Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Chronicles", 311.0, "Legendary Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Conquest", 832.0, "Galactic Games" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Quest", 862.0, "Mythical Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Chronicles", 816.0, "Mythical Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Manor", 742.0, "Empire Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Magic", 570.0, "Adventure Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Quest", 200.0, "Adventure Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Quest", 222.0, "Empire Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Magic", 417.0, "Adventure Studios" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Battles", 740.0, "Adventure Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Manor", 940.0, "Mystic Entertainment" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Adventure Chronicles", 553.0, "Galactic Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Kingdoms Quest", 610.0, "Galactic Co." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Epic Magic", 622.0, "Mystic Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Manor", 215.0, "Adventure Productions" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Mystic Quest", 767.0, "Mythical Creations" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Ancient Battles", 329.0, "Legendary Studios" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "Review",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "name", "price", "producer" },
                values: new object[] { "Galactic Conquest", 934.0, "Adventure Productions" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Review_user_name",
                table: "Review",
                column: "user_name");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_user_name",
                table: "Review",
                column: "user_name",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
