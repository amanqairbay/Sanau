namespace Application.Common.DTOs;

/// <summary>
/// Represents a product data transfer object for updating.
/// </summary>
/// <param name="Name">Product name.</param>
/// <param name="Price">Product price.</param>
public record ProductForUpdateDto(string Name, decimal Price);