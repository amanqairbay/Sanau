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
}