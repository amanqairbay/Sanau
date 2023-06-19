namespace Application.Common.DTOs;

/// <summary>
/// Represents a categoy data transfer object.
/// </summary>
/// <param name="Id">Category identifier.</param>
/// <param name="Name">Category name.</param>
/// <param name="Description">Category description.</param>
public record CategoryDto(Guid Id, string Name, string Description);