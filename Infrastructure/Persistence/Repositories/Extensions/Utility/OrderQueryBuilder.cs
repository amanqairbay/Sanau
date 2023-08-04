using Domain.Entities;
using System.Reflection;
using System.Text;

namespace Persistence.Repositories.Extensions.Utility;

/// <summary>
/// Represents a query builder order.
/// </summary>
public static class OrderQueryBuilder
{
    /// <summary>
    /// Creates an order query.
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    /// <param name="orderByQueryString">Query string.</param>
    /// <returns></returns>
    public static string CreateOrderQuery<T>(string orderByQueryString)
    {
        // Next, we are splitting our query string to get the individual fields.
        var orderParams = orderByQueryString.Trim().Split(',');

        // We’re also using a bit of reflection to prepare the list of PropertyInfo objects
        // that represent the properties of our Product class.
        // We need them to be able to check if the field received
        // through the query string exists in the Product class.
        var propertyInfos = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        // We can actually run through all the parameters and check for their existence.
        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            // If we don’t find such a property, we skip the step in the foreach loop
            // and go to the next parameter in the list.
            if (objectProperty == null)
                continue;

            // If we do find the property, we return it and additionally check
            // if our parameter contains “desc” at the end of the string.
            // We use that to decide how we should order our property
            var direction = param.EndsWith(" desc") ? "descending" : "ascending";

            // We use the StringBuilder to build our query with each loop.
            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
        }

        // Now that we’ve looped through all the fields, we are just removing excess commas.
        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

        // Returning our query.
        return orderQuery;
    }
}