using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Identity;

/// <summary>
/// Represents an user address.
/// </summary>
public class Address
{
    /// <summary>
    /// Gets or sets an address identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a user firstname.
    /// </summary>
    public string FirstName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user lastname.
    /// </summary>
    public string LastName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user state.
    /// </summary>
    public string State { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user city.
    /// </summary>
    public string City { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user address street.
    /// </summary>
    public string Street { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user address zipcode.
    /// </summary>
    public string ZipCode { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user identifier.
    /// </summary>
    [Required]
    public string AppUserId { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user.
    /// </summary>
    public AppUser AppUser { get; set; } = default!;
}