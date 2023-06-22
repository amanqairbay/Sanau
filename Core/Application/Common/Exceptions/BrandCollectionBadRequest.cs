namespace Application.Common.Exceptions;

/// <summary>
/// Represents a bad request exception for brand collection.
/// </summary>
public sealed class BrandCollectionBadRequest : BadRequestException
{
    public BrandCollectionBadRequest() : base("Brand collection sent from a client is null.")
    { }
}