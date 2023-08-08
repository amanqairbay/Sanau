namespace Domain.Entities;

/// <summary>
/// Represents a customer basket.
/// </summary>
public class CustomerBasket
{ 
    /// <summary>
    /// Gets or sets a basket identifier.
    /// </summary>
    public string Id { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a basket items.
    /// </summary>
    public List<BasketItem> Items { get; set; } = default!;

    #region constructor

    public CustomerBasket() { }

    public CustomerBasket(string id) => Id = id;

    #endregion constructor
}