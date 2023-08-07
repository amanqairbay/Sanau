using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Application.Common.Helpers;

/// <summary>
/// Extension point to provide custom resolution for a destination value.
/// </summary>
/// <typeparam name="TSource">Souce object.</typeparam>
/// <typeparam name="TDestination">Destination object.</typeparam>
public class ImageUrlResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, string>
{
    private readonly IConfiguration _configuration;

#region constructor

    public ImageUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

#endregion constructor

    /// <summary>
    /// Implementors use source object to provide a destination object.
    /// </summary>
    /// <param name="source">Source object.</param>
    /// <param name="destination">Destination object, if exists.</param>
    /// <param name="destMember">Destination member.</param>
    /// <param name="context">The context of the mapping.</param>
    /// <returns>Result, typically build from the source resolution result.</returns>
    public string Resolve(TSource source, TDestination destination, string destMember, ResolutionContext context)
    {
        var imageUrlProperty = source!
            .GetType()
            .GetProperty("ImageUrl")!
            .GetValue(source, null);

        string imageUrl = (string)imageUrlProperty!;

        if (!string.IsNullOrEmpty(imageUrl))
        {
            return _configuration["ApiUrl"] + imageUrl;
        }

        return null!;
    }
}