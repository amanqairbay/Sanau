using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasData
        (
            new Brand
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Apple",
                Description = "Apple Inc. is an American multinational technology company headquarted in Cupertino, California.",
                ImageUrl ="images/brands/logo/apple_black.png"
            },
            new Brand
            {
                Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "Samsung",
                Description = "Samsung is is a South Korean multinational manufacturing conglomerate headquartered in Samsung Town, Seoul, South Korea.",
                ImageUrl = "images/brands/logo/samsung_blue.png"
            },
            new Brand
            {
                Id = new Guid("d68fe072-2a4c-4990-acdb-08db70f8ca7e"),
                Name = "Xiaomi",
                Description = "Xiaomi Corporation is a Chinese designer and manufacturer of consumer electronics and related software items.",
                ImageUrl = "images/brands/logo/xiaomi.png"
            },
            new Brand
            {
                Id = new Guid("a00b5685-3066-4665-acdc-08db70f8ca7e"),
                Name = "Dell",
                Description = "Dell Inc. is an American based technology company. It develops, sells, repairs, and supports computers and related products and services.",
                ImageUrl = "images/brands/logo/dell.png"
            },
            new Brand
            {
                Id = new Guid("e2c7db35-24ee-4661-3f2a-08db7287ca33"),
                Name = "Sony",
                Description = "Sony is a Japanese multinational conglomerate corporation headquartered in Minato, Tokyo, Japan.",
                ImageUrl = "images/brands/logo/sony.png"
            },new Brand
            {
                Id = new Guid("8203e247-da1b-4922-3f2b-08db7287ca33"),
                Name = "Motorola",
                Description = "Motorola is an American multinational telecommunications company based in Schaumburg, Illinois.",
                ImageUrl = "images/brands/logo/motorola.png"
            }
        );
    }
}