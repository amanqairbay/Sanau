using Domain.Entities;
using Domain.Entities.OrderAggregate;
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
    public DbSet<Brand> Brands { get; set; } = default!;

    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    public DbSet<Product> Products {get; set; } = default!;

    /// <summary>
    /// Gets or sets the categories.
    /// </summary>
    public DbSet<Category> Categories {get; set; } = default!;

    /// <summary>
    /// Gets or sets the orders.
    /// </summary>
    public DbSet<Order> Orders { get; set; } = default!;

    /// <summary>
    /// Gets or sets the order items.
    /// </summary>
    public DbSet<OrderItem> OrderItems { get; set; } = default!;

    /// <summary>
    /// Gets or sets the delivery methods.
    /// </summary>
    public DbSet<DeliveryMethod> DeliveryMethods { get; set; } = default!;

    #endregion fields

    #region constructor

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

#endregion constructor

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new DeliveryMethodConfiguration());
    }
}