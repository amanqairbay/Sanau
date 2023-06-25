﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(38,2)", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Samsung is is a South Korean multinational manufacturing conglomerate headquartered in Samsung Town, Seoul, South Korea.", "Samsung" },
                    { new Guid("8203e247-da1b-4922-3f2b-08db7287ca33"), "Motorola is an American multinational telecommunications company based in Schaumburg, Illinois.", "Motorola" },
                    { new Guid("a00b5685-3066-4665-acdc-08db70f8ca7e"), "Dell Inc. is an American based technology company. It develops, sells, repairs, and supports computers and related products and services.", "Dell" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Apple Inc. is an American multinational technology company headquarted in Cupertino, California.", "Apple" },
                    { new Guid("d68fe072-2a4c-4990-acdb-08db70f8ca7e"), "Xiaomi Corporation is a Chinese designer and manufacturer of consumer electronics and related software items.", "Xiaomi" },
                    { new Guid("e2c7db35-24ee-4661-3f2a-08db7287ca33"), "Sony is a Japanese multinational conglomerate corporation headquartered in Minato, Tokyo, Japan.", "Sony" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("323c0bf7-c4b5-4b0c-58db-08db718ecbd1"), "Category of electronic goods", "Smartwatches" },
                    { new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"), "Category of electronic goods", "Laptops" },
                    { new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Category of electronic goods", "Smartphones" },
                    { new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"), "Category of electronic goods", "Tablets" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("34712f2c-46d5-4920-fd81-08db73e17d2c"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("323c0bf7-c4b5-4b0c-58db-08db718ecbd1"), "Apple Midnight Aluminum Case with Sport Loop", 1120m },
                    { new Guid("39348e22-1a62-444c-b62b-575ece82c251"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"), "Apple iPad 11 128Gb", 930m },
                    { new Guid("41d749b4-6381-4281-a513-eb5552a22996"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"), "Apple iPad 10.2 64Gb", 260m },
                    { new Guid("5bcdada4-71ef-45e2-b3c3-08db731e86dd"), new Guid("8203e247-da1b-4922-3f2b-08db7287ca33"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Motorola Razr 64Gb", 230m },
                    { new Guid("6519c192-93c5-48e6-bb34-04ed481f90ca"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"), "Samsung Galaxy Book3 Ultra", 800m },
                    { new Guid("8d8a7376-49ee-4f6c-89c0-f555c04b4caa"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"), "Samsung Galaxy Book3 Pro 360", 1100m },
                    { new Guid("aba5a6ca-2625-4d9a-9130-8fee866667ee"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"), "Apple MacBook Air 13 MGN63 Silver", 970m },
                    { new Guid("b04d673e-7317-4524-fd7f-08db73e17d2c"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("323c0bf7-c4b5-4b0c-58db-08db718ecbd1"), "Apple Silver Aluminum Case with Sport Band", 399m },
                    { new Guid("b295bbe2-03c8-437a-de07-08db71b2f7e8"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Samsung Galaxy A03 4Gb/64Gb", 145m },
                    { new Guid("b2c21d7d-410d-4435-b86d-82590ae58937"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Samsung Galaxy A23 6Gb/128Gb", 210m },
                    { new Guid("b48f982c-02a5-47b0-922b-b8ac76524a39"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"), "Apple MacBook Air 13 MGND3 Gold", 1000m },
                    { new Guid("c0cbd5fe-454b-4be9-a4b0-859d70c8cc82"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Apple iPhone 12 128Gb", 420m },
                    { new Guid("cfcec647-6934-4627-9fdb-8694ca5302ff"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"), "Samsung Galaxy Tab A8 10.5 SM-X205N", 220m },
                    { new Guid("d25d4d14-bf96-4dee-a5b3-d3bd0a083ade"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Samsung Galaxy A13 4Gb/64Gb", 160m },
                    { new Guid("def34053-91a6-4086-bfe6-19115867d5bb"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"), "Samsung Galaxy Tab A7 Lite 8.7 SM-T220", 110m },
                    { new Guid("e2a61f54-c74d-4ebf-fd82-08db73e17d2c"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Apple iPhone 14 Pro 256Gb", 1120m },
                    { new Guid("f31707ce-d118-45a0-86fe-bbcfed519301"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Apple iPhone 14 Pro 128Gb", 920m },
                    { new Guid("fdb7556f-f61a-4024-fd80-08db73e17d2c"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("323c0bf7-c4b5-4b0c-58db-08db718ecbd1"), "Apple Starlight Aluminum Case with Braided Solo Loop", 449m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
