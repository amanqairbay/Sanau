using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

/// <summary>
/// Represents an application user.
/// </summary>
public class AppUser : IdentityUser
{
    /// <summary>
    /// Gets or sets an user address.
    /// </summary>
    public Address Address { get; set; } = default!;

    /// <summary>
    /// Gets or sets a refresh token.
    /// </summary>
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Gets or sets a refress token's expiry time.
    /// </summary>
    public DateTime RefreshTokenExpiryTime { get; set; }
}