using System;
using Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

/// <summary>
/// Represents a delivery method configuration.
/// </summary>
public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
{
    public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
    {
        builder.Property(dm => dm.Price).HasColumnType("decimal(38,2)");

        builder.HasData
        (
            new DeliveryMethod
            {
                Id = new Guid("0747c069-6463-47fa-8604-229a9e93ed8a"),
                ShortName = "UPS1",
                Description = "Fastest delivery time",
                DeliveryTime = "1-2 Days",
                Price = 10
            },
            new DeliveryMethod
            {
                Id = new Guid("12b13ad8-1edf-4075-afd5-bf3b5b413220"),
                ShortName = "UPS2",
                Description = "Get it within 5 days",
                DeliveryTime = "2-5 Days",
                Price = 5
            },
            new DeliveryMethod
            {
                Id = new Guid("ee00c5a6-bb2d-454b-ab4a-f28fdc9d1d9f"),
                ShortName = "UPS3",
                Description = "Slower but cheap",
                DeliveryTime = "5-10 Days",
                Price = 2
            },
            new DeliveryMethod
            {
                Id = new Guid("bdca0a3a-2087-4861-9e77-6965fe1b0d34"),
                ShortName = "FREE",
                Description = "Free! You get what you pay for",
                DeliveryTime = "1-2 Weeks",
                Price = 0
            }
        );
    }
}