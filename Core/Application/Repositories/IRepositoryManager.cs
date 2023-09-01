namespace Application.Repositories;

public interface IRepositoryManager
{
    /// <summary>
    /// Gets a brand repository.
    /// </summary>
    IBrandRepository BrandRepository { get; }

    /// <summary>
    /// Gets a basket repository.
    /// </summary>
    IBasketRepository BasketRepository { get; }

    /// <summary>
    /// Gets a category repository.
    /// </summary>
    ICategoryRepository CategoryRepository { get; } 

    /// <summary>
    /// Gets a product repository.
    /// </summary>
    IProductRepository ProductRepository { get; }

    /// <summary>
    /// Gets an order repository.
    /// </summary>
    IOrderRepository OrderRepository { get; }

    /// <summary>
    /// Gets a delivery method repository.
    /// </summary>
    IDeliveryMethodRepository DeliveryMethodRepository { get; }

    /// <summary>
    /// Saves all changes made in this repository to the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task SaveAsync();
}