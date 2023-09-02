namespace Application.Common.Exceptions;

/// <summary>
/// Represents an exception bad request.
/// </summary>
public sealed class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }
}