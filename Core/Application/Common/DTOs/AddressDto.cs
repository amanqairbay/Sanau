namespace Application.Common.DTOs;

/// <summary>
/// Represents a data transfer object for address.
/// </summary>
/// <param name="FirstName">User's first name.</param>
/// <param name="LastName">User's last name</param>
/// <param name="State">State.</param>
/// <param name="City">City.</param>
/// <param name="Street">Street.</param>
/// <param name="ZipCode">Zip code.</param>
public record AddressDto(
    string FirstName,
    string LastName,
    string State,
    string City,
    string Street,
    string ZipCode);