using Application.Repositories;
using Application.Services;
using Domain.Logging;

namespace Persistence.Services;

/// <summary>
/// Represents a product service.
/// </summary>
internal sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public ProductService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}