namespace Application.Common.DTOs;

/// <summary>
/// Represents a brand data transfer object.
/// </summary>
/// <param name="Id">Brand identifier.</param>
/// <param name="Name">Brand name.</param>
/// <param name="Description">Brand description.</param>
public record BrandDto(Guid Id, string Name, string Description);