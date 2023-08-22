using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for a customer basket.
/// </summary>
public record CustomerBasketDto
{
    /// <summary>
    /// Gets or initializes a basket identifier.
    /// </summary>
    [Required]
    public string Id { get; init; }

    /// <summary>
    /// Gets or initializes a basket items.
    /// </summary>
    public List<BasketItemDto> Items { get; init; }
}