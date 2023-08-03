using Domain.Entities;

namespace Persistence.Repositories.Extensions;

/// <summary>
/// Represnts extensions for Product Repository class.
/// </summary>
public static class ProductRepositoryExtensions
{
    /// <summary>
    /// Finds and filters products according to criteria.
    /// </summary>
    /// <param name="products">Products to be filtered.</param>
    /// <param name="minPrice">Product minimum price.</param>
    /// <param name="maxPrice">Product</param>
    /// <returns>Returns filtered productsю</returns>
    public static IQueryable<Product> FilterProducts(this IQueryable<Product> products,
        decimal minPrice, decimal maxPrice) =>
            products.Where(p => (p.Price >= minPrice && p.Price <= maxPrice));

    /// <summary>
    /// Searches for products in the database.
    /// </summary>
    /// <param name="products">Products.</param>
    /// <param name="searchTerm">Search Tearm.</param>
    /// <returns></returns>
    public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return products;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return products.Where(p => p.Name!.ToLower().Contains(lowerCaseTerm));
    }
}