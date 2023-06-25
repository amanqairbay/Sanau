using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData
        (
            new Category
            {
                Id = new Guid("9e6fb337-af84-4046-9a9c-ddc4e4e6e640"),
                Name = "Smartphones",
                Description  =  "Category of electronic goods"
            },
            new Category
            {
                Id = new Guid("bd84693a-702e-4fb2-ba16-d93ae8e8e204"),
                Name = "Tablets",
                Description  =  "Category of electronic goods"
            },
            new Category
            {
                Id = new Guid("94a41fec-e15f-4d46-ac7d-2e648168f051"),
                Name = "Laptops",
                Description  =  "Category of electronic goods"
            },
            new Category
            {
                Id = new Guid("323c0bf7-c4b5-4b0c-58db-08db718ecbd1"),
                Name = "Smartwatches",
                Description  =  "Category of electronic goods"
            }
        );
    }
}