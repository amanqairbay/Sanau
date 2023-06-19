namespace Application.Common.DTOs;

/// <summary>
/// Represents a product data transfer object.
/// </summary>
/// <param name="Id">Product Id.</param>
/// <param name="Name">Product name.</param>
/// <param name="Price">Product price.</param>
public record ProductDto(Guid Id, string Name, decimal Price);