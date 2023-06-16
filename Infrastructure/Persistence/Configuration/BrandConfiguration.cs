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
                Description = "Apple Inc. is an American multinational technology company headquarted in Cupertino, California."
            },
            new Brand
            {
                Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "Samsung",
                Description = "Samsung is is a South Korean multinational manufacturing conglomerate headquartered in Samsung Town, Seoul, South Korea."
            }
        );
    }
}