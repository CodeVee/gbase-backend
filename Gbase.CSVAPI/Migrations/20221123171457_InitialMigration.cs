using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gbase.CSVAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductCase",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCase", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductCondition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCondition", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Make = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DealerKey = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DealerNotes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CaseId = table.Column<long>(type: "bigint", nullable: true),
                    TypeId = table.Column<long>(type: "bigint", nullable: true),
                    ConditionId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCase_CaseId",
                        column: x => x.CaseId,
                        principalTable: "ProductCase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_ProductCondition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "ProductCondition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_ProductType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductLink",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLink_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductPicture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPicture_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ProductCase",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "None" },
                    { 2L, "Hard" },
                    { 3L, "Soft" },
                    { 4L, "GigBag" },
                    { 5L, "Original Hard" },
                    { 6L, "Original Soft" }
                });

            migrationBuilder.InsertData(
                table: "ProductCondition",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Brand New" },
                    { 2L, "Mint" },
                    { 3L, "Near Mint" },
                    { 4L, "Excellent" },
                    { 5L, "Very Good" },
                    { 6L, "Good" },
                    { 7L, "Fair" },
                    { 8L, "Poor" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Guitars : Electric Solid Body" },
                    { 2L, "Guitars : Electric Semi-Hollow Body" },
                    { 3L, "Guitars : 12 String Electric & Acoustic" },
                    { 4L, "Guitars : Acoustic" },
                    { 5L, "Guitars : Flattop Electric & Acoustic" },
                    { 6L, "Guitars : Archtop Electric & Acoustic" },
                    { 7L, "Guitars : Classical & Nylon" },
                    { 8L, "Guitars : 7 String" },
                    { 9L, "Guitars : Lap, Pedal & Table" },
                    { 10L, "Guitars : Resonator" },
                    { 11L, "Guitars : Tenor" },
                    { 12L, "Guitars : Bass" },
                    { 13L, "Guitars : Upright Bass" },
                    { 14L, "Guitars : Hollow Body" },
                    { 15L, "Amps & Preamps" },
                    { 16L, "Amp Parts" },
                    { 17L, "Amp Speakers" },
                    { 18L, "Amp Tubes" },
                    { 19L, "Speaker Cabinets" },
                    { 20L, "Drums & Percussion" },
                    { 21L, "Bass Speaker Cabinets" },
                    { 22L, "Bass Amps" },
                    { 23L, "Band & Orchestra" },
                    { 24L, "Banjos" },
                    { 25L, "Effects" },
                    { 26L, "Mandolin Family" },
                    { 27L, "P.A. & Sound Reinforcement" },
                    { 28L, "Pickups" },
                    { 29L, "Recording Equipment" },
                    { 30L, "Ukulele & Banjo Ukes" },
                    { 31L, "Accessories" },
                    { 32L, "Apparel" },
                    { 33L, "Books, Videos & Instrumental" },
                    { 34L, "Close Out Items" },
                    { 35L, "Guitar Parts" },
                    { 36L, "High End Audio" },
                    { 37L, "Karaoke" },
                    { 38L, "Miscellaneous" },
                    { 39L, "Music Novelities" },
                    { 40L, "Software" },
                    { 41L, "Keyboards" },
                    { 42L, "Cases" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CaseId",
                table: "Product",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ConditionId",
                table: "Product",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeId",
                table: "Product",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLink_ProductId",
                table: "ProductLink",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_ProductId",
                table: "ProductPicture",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLink");

            migrationBuilder.DropTable(
                name: "ProductPicture");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductCase");

            migrationBuilder.DropTable(
                name: "ProductCondition");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
