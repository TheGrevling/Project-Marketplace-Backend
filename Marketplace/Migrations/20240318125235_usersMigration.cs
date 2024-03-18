using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marketplace.Migrations
{
    /// <inheritdoc />
    public partial class usersMigration : Migration
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
                    imageURL = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_product_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Product_fk_product_id",
                        column: x => x.fk_product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "imageURL", "name", "price", "producer" },
                values: new object[,]
                {
                    { 1, 0, "Description of boardgame", "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg", "Adventure Quest", 665.0, "Galactic Studios" },
                    { 2, 0, "Description of boardgame", "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg", "Kingdoms Battles", 991.0, "Empire Studios" },
                    { 3, 0, "Description of boardgame", "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg", "Mystic Battles", 128.0, "Empire Games" },
                    { 4, 0, "Description of boardgame", "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg", "Adventure Chronicles", 605.0, "Galactic Entertainment" },
                    { 5, 0, "Description of boardgame", "https://gamezone.no/Media/Cache/Images/4/7/WEB_Image_Catan_Grunnspill_(Norsk)_Brettspill__catan-grunnspill820591365_plid_44797.jpeg", "Epic Magic", 927.0, "Mystic Creations" },
                    { 6, 1, "Description of cardgame", "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg", "Adventure Quest", 975.0, "Mystic Co." },
                    { 7, 1, "Description of cardgame", "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg", "Galactic Chronicles", 436.0, "Mystic Productions" },
                    { 8, 1, "Description of cardgame", "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg", "Epic Conquest", 560.0, "Legendary Games" },
                    { 9, 1, "Description of cardgame", "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg", "Mystic Battles", 564.0, "Galactic Creations" },
                    { 10, 1, "Description of cardgame", "https://gamezone.no/Media/Cache/Images/8/0/WEB_Image_Magic_Murder_Karlov_Manor_Play_Display__mtgmkm_en_bstrdspbx_drft_01_011402134032_plid_87420.jpeg", "Galactic Quest", 593.0, "Empire Co." },
                    { 11, 2, "Description of roleplay", "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg", "Galactic Conquest", 464.0, "Adventure Entertainment" },
                    { 12, 2, "Description of roleplay", "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg", "Epic Conquest", 535.0, "Empire Productions" },
                    { 13, 2, "Description of roleplay", "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg", "Ancient Manor", 517.0, "Galactic Co." },
                    { 14, 2, "Description of roleplay", "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg", "Epic Chronicles", 553.0, "Galactic Co." },
                    { 15, 2, "Description of roleplay", "https://gamezone.no/Media/Cache/Images/7/0/WEB_Image_D_D_Essentials_Kit_Dungeons___Dragons__dnd-essentials-kit547970669.jpeg", "Mystic Quest", 895.0, "Adventure Productions" },
                    { 16, 3, "Description of puzzlegame", "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg", "Adventure Battles", 202.0, "Legendary Studios" },
                    { 17, 3, "Description of puzzlegame", "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg", "Epic Conquest", 419.0, "Mystic Creations" },
                    { 18, 3, "Description of puzzlegame", "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg", "Mystic Chronicles", 674.0, "Mystic Studios" },
                    { 19, 3, "Description of puzzlegame", "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg", "Ancient Battles", 288.0, "Mystic Creations" },
                    { 20, 3, "Description of puzzlegame", "https://gamezone.no/Media/Cache/Images/6/5/WEB_Image_Bicycles_in_Amsterdam_1000_biter_Puslesp_bikes-in-amsterdam-577910530.jpeg", "Mystic Manor", 664.0, "Empire Entertainment" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_fk_product_id",
                table: "Reviews",
                column: "fk_product_id");
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
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
