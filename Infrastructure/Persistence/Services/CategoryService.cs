using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Logging;

namespace Persistence.Services;

internal sealed class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CategoryService(
        IRepositoryManager repository, 
        ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
}