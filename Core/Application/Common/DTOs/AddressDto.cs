using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for address.
/// </summary>
public record AddressDto
{
    /// <summary>
    /// Gets or initializes a user's firstname.
    /// </summary>
    [Required]
    public string FirstName { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a user's lastname.
    /// </summary>
    [Required]
    public string LastName { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a user's state.
    /// </summary>
    [Required]
    public string State { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a user's city.
    /// </summary>
    [Required]
    public string City { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a user's address street.
    /// </summary>
    [Required]
    public string Street { get; init; } = String.Empty;

    /// <summary>
    /// Gets or initializes a user's address zipcode.
    /// </summary>
    [Required]
    public string ZipCode { get; init; } = String.Empty;
}