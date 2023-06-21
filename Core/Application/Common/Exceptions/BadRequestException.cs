namespace Application.Common.Exceptions;

/// <summary>
/// Represents an abstract class, that is the base class for all individual bad request exception classes. 
/// It inherits from the Exception class to represent the errors that occur during application execution.
/// </summary>
public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message) : base(message)
    {
        
    }
}
