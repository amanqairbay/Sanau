namespace Application.Common.Exceptions;

/// <summary>
/// Represents a bad request exception for maximum price range.
/// </summary>
public sealed class MaxPriceRangeBadRequestException : BadRequestException
{
    public MaxPriceRangeBadRequestException() : base("Max price can't be less than min price.")
    {
        
    }
}