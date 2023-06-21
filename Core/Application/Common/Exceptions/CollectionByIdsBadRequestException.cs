namespace Application.Common.Exceptions;

/// <summary>
/// Represents a bad request exception for collection entities.
/// </summary>
public sealed class CollectionByIdsBadRequestException : BadRequestException 
{
    public CollectionByIdsBadRequestException() : base("Collection count mismatch comparing to ids.")
    { } 
}