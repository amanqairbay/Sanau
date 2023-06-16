using Application.Repositories;
using Application.Services;
using Domain.Logging;

namespace Persistence.Services;

internal sealed class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public CategoryService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}