﻿namespace Application.Common.Exceptions;

/// <summary>
/// Represents a bad request for check email exists.
/// </summary>
public class CheckEmailExistsBadRequest : BadRequestException
{
    public CheckEmailExistsBadRequest() : base("Email address is in use.")
    {
    }
}