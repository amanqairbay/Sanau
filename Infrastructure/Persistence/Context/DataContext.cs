using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;

namespace Persistence.Context;

/// <summary>
/// Represents the data context class.
/// </summary>
public class DataContext : DbContext
{
#region  fields
    /// <summary>
    /// Gets or sets the brands.
    /// </summary>
    public DbSet<Brand>? Brands {get; set;}

    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    public DbSet<Product>? Products {get; set;}

    /// <summary>
    /// Gets or sets the categories.
    /// </summary>
    public DbSet<Category>? Categories {get; set;}

#endregion fields

#region constructor

    public DataContext(DbContextOptions options) : base(options) { }

#endregion constructor

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}