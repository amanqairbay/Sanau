using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData
        (
            new Product
            {
                Id = new Guid("e2a61f54-c74d-4ebf-fd82-08db73e17d2c"),
                Name = "Apple iPhone 14 Pro 256Gb Deep Purple",
                Price = 1120,
                ImageUrl = "images/brands/products/apple_iphone_14_pro_256gb_deep_purple.jpeg",
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            },
            new Product
            {
                Id = new Guid("f31707ce-d118-45a0-86fe-bbcfed519301"),
                Name = "Apple iPhone 14 Pro 128Gb Gold",
                Price = 920,
                ImageUrl = "images/brands/products/apple_iphone_14_pro_128gb_gold.jpeg",
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            },
            new Product
            {
                Id = new Guid("c0cbd5fe-454b-4be9-a4b0-859d70c8cc82"),
                Name = "Apple iPhone 12 128Gb Silver",
                Price = 420,
                ImageUrl = "images/brands/products/apple_iphone_12_128gb_silver.jpeg",
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            },
            new Product
            {
                Id = new Guid("41d749b4-6381-4281-a513-eb5552a22996"),
                Name = "Apple iPad 10.2 64Gb Space Grey",
                Price = 260,
                ImageUrl = "images/brands/products/apple_ipad_10.2_64gb_space_grey.jpeg",
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204")
            },
            new Product
            {
                Id = new Guid("39348e22-1a62-444c-b62b-575ece82c251"),
                Name = "Apple iPad 11 128Gb Silver",
                Price = 930,
                ImageUrl = "images/brands/products/apple_ipad_11_128gb_silver.jpeg",
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204")
            },
            new Product
            {
                Id = new Guid("b04d673e-7317-4524-fd7f-08db73e17d2c"),
                Name = "Apple Silver Aluminum Case with Sport Band",
                Price = 399,
                ImageUrl = "images/brands/products/apple_silver_aluminum_case_with_sport_band.jpeg",
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("323c0bf7-c4b5-4b0c-58db-08db718ecbd1")
            },
            new Product
            {
                Id = new Guid("fdb7556f-f61a-4024-fd80-08db73e17d2c"),
                Name = "Apple Starlight Aluminum Case with Braided Solo Loop",
                Price = 449,
                ImageUrl = "images/brands/products/apple_starlight_aluminum_case_with_braided_solo_loop.jpeg",
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("323c0bf7-c4b5-4b0c-58db-08db718ecbd1")
            },
            new Product
            {
                Id = new Guid("34712f2c-46d5-4920-fd81-08db73e17d2c"),
                Name = "Apple Midnight Aluminum Case with Sport Loop",
                Price = 1120,
                ImageUrl = "images/brands/products/apple_midnight_aluminum_case_with_sport_loop.jpeg",
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("323c0bf7-c4b5-4b0c-58db-08db718ecbd1")
            },
            new Product
            {
                Id = new Guid("aba5a6ca-2625-4d9a-9130-8fee866667ee"),
                Name = "Apple MacBook Air 13 MGN63 Silver",
                Price = 970,
                ImageUrl = "images/brands/products/apple_macbook_air_13_mgn63_silver.jpeg",
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051")
            },
            new Product
            {
                Id = new Guid("b48f982c-02a5-47b0-922b-b8ac76524a39"),
                Name = "Apple MacBook Air 13 MGND3 Gold",
                Price = 1000,
                ImageUrl = "images/brands/products/apple_macbook_air_13_mgnd3_gold.jpeg",
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051")
            },
            new Product
            {
                Id = new Guid("b2c21d7d-410d-4435-b86d-82590ae58937"),
                Name = "Samsung Galaxy A23 6Gb/128Gb Black",
                Price = 210,
                ImageUrl = "images/brands/products/samsung_galaxy_a23 6gb_128gb_black.jpeg",
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            },
            new Product
            {
                Id = new Guid("d25d4d14-bf96-4dee-a5b3-d3bd0a083ade"),
                Name = "Samsung Galaxy A13 4Gb/64Gb Blue",
                Price = 160,
                ImageUrl = "images/brands/products/samsung_galaxy_a13_4gb_64gb_blue.jpeg",
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            },
            new Product
            {
                Id = new Guid("b295bbe2-03c8-437a-de07-08db71b2f7e8"),
                Name = "Samsung Galaxy A03 4Gb/64Gb Blue",
                Price = 145,
                ImageUrl = "images/brands/products/samsung_galaxy_a03_4gb_64gb_blue.jpeg",
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            },
            new Product
            {
                Id = new Guid("def34053-91a6-4086-bfe6-19115867d5bb"),
                Name = "Samsung Galaxy Tab A7 Lite 8.7 SM-T220 Gray",
                Price = 110,
                ImageUrl = "images/brands/products/samsung_galaxy_tab_a7_lite_8.7_sm-t220_gray.jpeg",
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204")
            },
            new Product
            {
                Id = new Guid("cfcec647-6934-4627-9fdb-8694ca5302ff"),
                Name = "Samsung Galaxy Tab A8 10.5 SM-X205N Gray",
                Price = 220,
                ImageUrl = "images/brands/products/samsung_galaxy_tab_a8_10.5_sm-x205n_gray.jpeg",
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204")
            },
            new Product
            {
                Id = new Guid("6519c192-93c5-48e6-bb34-04ed481f90ca"),
                Name = "Samsung Galaxy Book3 Ultra",
                Price = 800,
                ImageUrl = "images/brands/products/samsung_galaxy_book3_ultra.jpeg",
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051")
            },
            new Product
            {
                Id = new Guid("8d8a7376-49ee-4f6c-89c0-f555c04b4caa"),
                Name = "Samsung Galaxy Book3 Pro 360",
                Price = 1100,
                ImageUrl = "images/brands/products/samsung_galaxy_book3_pro_360.jpeg",
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051")
            },
            new Product
            {
                Id = new Guid("5bcdada4-71ef-45e2-b3c3-08db731e86dd"),
                Name = "Motorola Razr 64Gb",
                Price = 230,
                ImageUrl = "images/brands/products/motorola_razr_64gb.jpeg",
                BrandId = new Guid("8203e247-da1b-4922-3f2b-08db7287ca33"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            }
        );
    }
}