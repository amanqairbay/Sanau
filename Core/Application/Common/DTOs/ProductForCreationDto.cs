namespace Application.Common.DTOs;

/// <summary>
/// Represents a product object for creation.
/// </summary>
/// <param name="Name">Product name.</param>
/// <param name="Price">Product price.</param>
/// <param name="CategoryId">Category identifier.</param>
public record ProductForCreationDto(string Name, decimal Price, Guid CategoryId);