using Application.Repositories;
using Application.Services;
using Domain.Logging;

namespace Persistence.Services;

/// <summary>
/// Represents a brand service.
/// </summary>
internal sealed class BrandService : IBrandService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;

    public BrandService(IRepositoryManager repositoryManager, ILoggerManager logger)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
    }
}