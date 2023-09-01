namespace Application.Common.Exceptions;

/// <summary>
/// Represents a bad request exception for refresh token.
/// </summary>
public sealed class RefreshTokenBadRequest : BadRequestException
{
    public RefreshTokenBadRequest() : base("Invalid client request. The tokenDto has some invalid values.")
    {
    }
}