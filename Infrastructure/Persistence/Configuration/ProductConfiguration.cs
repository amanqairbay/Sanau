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
                Id = new Guid("f31707ce-d118-45a0-86fe-bbcfed519301"),
                Name = "Apple iPhone 14 Pro 128Gb",
                Price = 920,
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            },
            new Product
            {
                Id = new Guid("c0cbd5fe-454b-4be9-a4b0-859d70c8cc82"),
                Name = "Apple iPhone 12 128Gb",
                Price = 420,
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            },
            new Product
            {
                Id = new Guid("41d749b4-6381-4281-a513-eb5552a22996"),
                Name = "Apple iPad 10.2 64Gb",
                Price = 260,
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204")
            },
            new Product
            {
                Id = new Guid("39348e22-1a62-444c-b62b-575ece82c251"),
                Name = "Apple iPad 11 128Gb",
                Price = 930,
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204")
            },
            new Product
            {
                Id = new Guid("aba5a6ca-2625-4d9a-9130-8fee866667ee"),
                Name = "Apple MacBook Air 13 MGN63 Silver",
                Price = 970,
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051")
            },
            new Product
            {
                Id = new Guid("b48f982c-02a5-47b0-922b-b8ac76524a39"),
                Name = "Apple MacBook Air 13 MGND3 Gold",
                Price = 1000,
                BrandId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                CategoryId = new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051")
            },
            new Product
            {
                Id = new Guid("b2c21d7d-410d-4435-b86d-82590ae58937"),
                Name = "Samsung Galaxy A23 6Gb/128Gb",
                Price = 210,
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            },
            new Product
            {
                Id = new Guid("d25d4d14-bf96-4dee-a5b3-d3bd0a083ade"),
                Name = "Samsung Galaxy A13 4Gb/64Gb",
                Price = 160,
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640")
            },
            new Product
            {
                Id = new Guid("def34053-91a6-4086-bfe6-19115867d5bb"),
                Name = "Samsung Galaxy Tab A7 Lite 8.7 SM-T220",
                Price = 110,
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204")
            },
            new Product
            {
                Id = new Guid("cfcec647-6934-4627-9fdb-8694ca5302ff"),
                Name = "Samsung Galaxy Tab A8 10.5 SM-X205N",
                Price = 220,
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204")
            },
            new Product
            {
                Id = new Guid("6519c192-93c5-48e6-bb34-04ed481f90ca"),
                Name = "Samsung Galaxy Book3 Ultra",
                Price = 800,
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051")
            },
            new Product
            {
                Id = new Guid("8d8a7376-49ee-4f6c-89c0-f555c04b4caa"),
                Name = "Samsung Galaxy Book3 Pro 360",
                Price = 1100,
                BrandId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                CategoryId = new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051")
            }
        );
    }
}