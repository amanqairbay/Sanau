namespace Application.Common.Exceptions;

/// <summary>
/// Represents a bad request for updating the user's address.
/// </summary>
public sealed class UpdateUserAddressBadRequest : BadRequestException
{
    public UpdateUserAddressBadRequest() : base("Problems with updating the user.")
    {
    }
}