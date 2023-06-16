using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

/// <summary>
/// Represents the base class for entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Gets or sets the entity identifier.
    /// </summary>
    public Guid Id { get; set; }
}