using System.Text.Json;

namespace Domain.Entities.ErrorModel;

/// <summary>
/// Represents an error details class.
/// </summary>
public class ErrorDetails
{
    /// <summary>
    /// Gets or sets a status code.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Gets or sets an error message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    public override string ToString() => JsonSerializer.Serialize(this);
}