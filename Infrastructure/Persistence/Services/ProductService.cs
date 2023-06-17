using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Logging;

namespace Persistence.Services;

/// <summary>
/// Represents a product service.
/// </summary>
internal sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ProductService(
        IRepositoryManager repository, 
        ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
}