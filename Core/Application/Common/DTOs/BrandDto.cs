namespace Application.Common.DTOs;

/// <summary>
/// Represents a brand data transfer object.
/// </summary>
public record BrandDto
{
    /// <summary>
    /// Gets or initializes a brand identifier.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or initializes a brand name.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Gets or initializes a brand description.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Gets or initializes a brand image url.
    /// </summary>
    public string? ImageUrl { get; init; }
}