namespace Domain.Entities.ConfigurationModelsж;

/// <summary>
/// Represents a JWT configuration.
/// </summary>
public class JwtConfiguration
{
    /// <summary>
    /// Gets or sets a section.
    /// </summary>
    public string Section { get; set; } = "JwtSettings";

    /// <summary>
    /// Gets or sets a valid issuer.
    /// </summary>
    public string ValidIssuer { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a valid audience.
    /// </summary>
    public string ValidAudience { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a secret key.
    /// </summary>
    public string SecretKey { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets expires.
    /// </summary>
    public string Expires { get; set; } = String.Empty;
}