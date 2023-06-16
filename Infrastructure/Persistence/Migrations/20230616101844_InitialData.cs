using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Samsung is is a South Korean multinational manufacturing conglomerate headquartered in Samsung Town, Seoul, South Korea.", "Samsung" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Apple Inc. is an American multinational technology company headquarted in Cupertino, California.", "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"), "Category of electronic goods", "Laptop" },
                    { new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Category of electronic goods", "Smartphone" },
                    { new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"), "Category of electronic goods", "Tablet" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("39348e22-1a62-444c-b62b-575ece82c251"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"), "Apple iPad 11 128Gb", 930m },
                    { new Guid("41d749b4-6381-4281-a513-eb5552a22996"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"), "Apple iPad 10.2 64Gb", 260m },
                    { new Guid("6519c192-93c5-48e6-bb34-04ed481f90ca"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"), "Samsung Galaxy Book3 Ultra", 800m },
                    { new Guid("8d8a7376-49ee-4f6c-89c0-f555c04b4caa"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"), "Samsung Galaxy Book3 Pro 360", 1100m },
                    { new Guid("aba5a6ca-2625-4d9a-9130-8fee866667ee"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"), "Apple MacBook Air 13 MGN63 Silver", 970m },
                    { new Guid("b2c21d7d-410d-4435-b86d-82590ae58937"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Samsung Galaxy A23 6Gb/128Gb", 210m },
                    { new Guid("b48f982c-02a5-47b0-922b-b8ac76524a39"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"), "Apple MacBook Air 13 MGND3 Gold", 1000m },
                    { new Guid("c0cbd5fe-454b-4be9-a4b0-859d70c8cc82"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Apple iPhone 12 128Gb", 420m },
                    { new Guid("cfcec647-6934-4627-9fdb-8694ca5302ff"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"), "Samsung Galaxy Tab A8 10.5 SM-X205N", 220m },
                    { new Guid("d25d4d14-bf96-4dee-a5b3-d3bd0a083ade"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Samsung Galaxy A13 4Gb/64Gb", 160m },
                    { new Guid("def34053-91a6-4086-bfe6-19115867d5bb"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"), "Samsung Galaxy Tab A7 Lite 8.7 SM-T220", 110m },
                    { new Guid("f31707ce-d118-45a0-86fe-bbcfed519301"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"), "Apple iPhone 14 Pro 128Gb", 920m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("39348e22-1a62-444c-b62b-575ece82c251"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("41d749b4-6381-4281-a513-eb5552a22996"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6519c192-93c5-48e6-bb34-04ed481f90ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8d8a7376-49ee-4f6c-89c0-f555c04b4caa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aba5a6ca-2625-4d9a-9130-8fee866667ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2c21d7d-410d-4435-b86d-82590ae58937"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b48f982c-02a5-47b0-922b-b8ac76524a39"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0cbd5fe-454b-4be9-a4b0-859d70c8cc82"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfcec647-6934-4627-9fdb-8694ca5302ff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d25d4d14-bf96-4dee-a5b3-d3bd0a083ade"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("def34053-91a6-4086-bfe6-19115867d5bb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f31707ce-d118-45a0-86fe-bbcfed519301"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"));
        }
    }
}
