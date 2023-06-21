namespace Application.Common.Exceptions;

/// <summary>
/// Represents a bad request exception for id parameters.
/// </summary>
public sealed class IdParametersBadRequestException : BadRequestException
{
    public IdParametersBadRequestException() : base("Parameter ids is null.")
    {
        
    }
}