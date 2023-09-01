using Application.Repositories;
using Persistence.Context;
using StackExchange.Redis;

namespace Persistence.Repositories;

/// <summary>
/// Represents a repository manager.
/// </summary>
public class RepositoryManager : IRepositoryManager
{   
    // The RepositoryManager implementation is that we are leveraging 
    // the power of the Lazy class to ensure the lazy initialization of our repositories. 
    // This means that our repository instances are only going 
    // to be created when we access them for the first time, and not before that.

    #region fields

    private readonly DataContext _dataContext;
    private readonly Lazy<IBrandRepository> _brandRepository;
    private readonly Lazy<IBasketRepository> _basketRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IDeliveryMethodRepository> _deliveryMethodRepository;

    #endregion fields

    #region properties
    /// <summary>
    /// Gets a brand repository value. 
    /// </summary>
    public IBrandRepository BrandRepository => _brandRepository.Value;

    /// <summary>
    /// Gets a basket repository value. 
    /// </summary>
    public IBasketRepository BasketRepository => _basketRepository.Value;

    /// <summary>
    /// Gets a category repository value. 
    /// </summary>
    public ICategoryRepository CategoryRepository => _categoryRepository.Value;

    /// <summary>
    /// Gets a product repository value. 
    /// </summary>
    public IProductRepository ProductRepository => _productRepository.Value;

    /// <summary>
    /// Gets an order repository value. 
    /// </summary>
    public IOrderRepository OrderRepository => _orderRepository.Value;

    /// <summary>
    /// Gets a delivery method repository value. 
    /// </summary>
    public IDeliveryMethodRepository DeliveryMethodRepository => _deliveryMethodRepository.Value;

    #endregion properties

    #region constructor

    public RepositoryManager(DataContext dataContext, IConnectionMultiplexer redis)
    {
        _dataContext = dataContext;
        _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(dataContext));
        _basketRepository = new Lazy<IBasketRepository>(() => new BasketRepository(redis));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(dataContext));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(dataContext));
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(dataContext));
        _deliveryMethodRepository = new Lazy<IDeliveryMethodRepository>(() => new DeliveryMethodRepository(dataContext));
    }

    #endregion constructor

    /// <summary>
    /// Saves all changes made in this repository to the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task SaveAsync() => await _dataContext.SaveChangesAsync();
}