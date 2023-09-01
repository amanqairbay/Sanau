namespace Domain.Entities.OrderAggregate;

/// <summary>
/// Represents an address.
/// </summary>
public class Address
{
    #region properties

    /// <summary>
    /// Gets or sets a user firstname.
    /// </summary>
    public string FirstName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user lastname.
    /// </summary>
    public string LastName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user state.
    /// </summary>
    public string State { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user city.
    /// </summary>
    public string City { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user address street.
    /// </summary>
    public string Street { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a user address zipcode.
    /// </summary>
    public string ZipCode { get; set; } = String.Empty;

    #endregion properties

    #region constructor

    public Address()
    {

    }

    public Address(string firstName, string lastName, string state, string city, string street, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        State = state;
        City = city;
        Street = street;
        ZipCode = zipCode;
    }

    #endregion constructor
}

