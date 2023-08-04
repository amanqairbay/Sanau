using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using Domain.Entities;
using Persistence.Repositories.Extensions.Utility;
using static System.Net.Mime.MediaTypeNames;

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
    /// <param name="maxPrice">Product maximum price.</param>
    /// <returns>Returns filtered products.</returns>
    public static IQueryable<Product> FilterProducts(this IQueryable<Product> products,
        decimal minPrice, decimal maxPrice) =>
            products.Where(p => (p.Price >= minPrice && p.Price <= maxPrice));

    /// <summary>
    /// Searches for products in the database.
    /// </summary>
    /// <param name="products">Products.</param>
    /// <param name="searchTerm">Search Term.</param>
    /// <returns>Returns the found products.</returns>
    public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return products;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return products.Where(p => p.Name!.ToLower().Contains(lowerCaseTerm));
    }

    /// <summary>
    /// Sorts the products by query string.
    /// </summary>
    /// <param name="products">Products.</param>
    /// <param name="orderByQueryString">Query string.</param>
    /// <returns>Returns sorted products.</returns>
    public static IQueryable<Product> Sort(this IQueryable<Product> products, string orderByQueryString)
    {
        // We begin by executing some basic check against the orderByQueryString.
        // If it is null or empty, we just return the same collection ordered by name.
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return products.OrderBy(p => p.Name);

        // Creating a query.
        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

        // We are doing one last check to see if our query indeed has something in it.
        if (string.IsNullOrWhiteSpace(orderQuery))
            return products.OrderBy(p => p.Name);

        // Finally, we can order our query.
        return products.OrderBy(orderQuery);
    }
}