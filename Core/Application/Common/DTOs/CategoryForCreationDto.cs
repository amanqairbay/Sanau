namespace Application.Common.DTOs;

/// <summary>
/// Represents a category for creation data transfer object.
/// </summary>
/// <param name="Name">Category name.</param>
/// <param name="Description">Category description.</param>
public record CategoryForCreationDto(string Name, string Description);