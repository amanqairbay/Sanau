namespace Application.Common.DTOs;

/// <summary>
/// Represents a brand for creation data transfer object.
/// </summary>
/// <param name="Name">Brand name.</param>
/// <param name="Description">Brand description.</param>
public record BrandForCreationDto(string Name, string Description);