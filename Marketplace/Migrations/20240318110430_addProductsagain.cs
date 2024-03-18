using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marketplace.Migrations
{
    /// <inheritdoc />
    public partial class addProductsagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    producer = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    category = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "description", "ImageURL", "name", "price", "producer", "category" },
                values: new object[,]
                {
                    { 1, "Description of boardgame", "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg", "Kingdoms Conquest", 690.0, "Mystic Entertainment", 0 },
                    { 2, "Description of boardgame", "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg", "Epic Conquest", 322.0, "Legendary Co.", 0 },
                    { 3, "Description of boardgame", "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg", "Mystic Battles", 355.0, "Adventure Co.", 0 },
                    { 4, "Description of boardgame", "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg", "Kingdoms Conquest", 157.0, "Galactic Studios", 0 },
                    { 5, "Description of boardgame", "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg", "Galactic Battles", 734.0, "Mythical Studios", 0 },
                    { 6, "Description of cardgame", "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg", "Adventure Manor", 689.0, "Legendary Studios", 1 },
                    { 7, "Description of cardgame", "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg", "Epic Chronicles", 624.0, "Empire Co.", 1 },
                    { 8, "Description of cardgame", "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg", "Galactic Quest", 410.0, "Adventure Productions", 1 },
                    { 9, "Description of cardgame", "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg", "Ancient Manor", 723.0, "Mythical Creations", 1 },
                    { 10, "Description of cardgame", "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg", "Ancient Battles", 947.0, "Mystic Entertainment", 1 },
                    { 11, "Description of roleplay", "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg", "Mystic Conquest", 898.0, "Empire Productions", 2 },
                    { 12, "Description of roleplay", "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg", "Ancient Magic", 877.0, "Mystic Studios", 2 },
                    { 13, "Description of roleplay", "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg", "Mystic Manor", 303.0, "Galactic Productions", 2 },
                    { 14, "Description of roleplay", "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg", "Adventure Quest", 958.0, "Galactic Creations", 2 },
                    { 15, "Description of roleplay", "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg", "Mystic Chronicles", 481.0, "Empire Creations", 2 },
                    { 16, "Description of puzzlegame", "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg", "Ancient Conquest", 895.0, "Galactic Studios", 3 },
                    { 17, "Description of puzzlegame", "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg", "Galactic Conquest", 589.0, "Galactic Games", 3 },
                    { 18, "Description of puzzlegame", "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg", "Ancient Manor", 399.0, "Empire Games", 3 },
                    { 19, "Description of puzzlegame", "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg", "Adventure Magic", 917.0, "Legendary Entertainment", 3 },
                    { 20, "Description of puzzlegame", "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg", "Mystic Battles", 463.0, "Galactic Entertainment", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
