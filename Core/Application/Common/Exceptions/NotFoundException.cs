namespace Application.Common.Exceptions;

/// <summary>
/// Represents an exception not found.
/// </summary>
public sealed class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
        
    }
}