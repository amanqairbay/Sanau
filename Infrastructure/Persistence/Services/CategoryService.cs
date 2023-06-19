using Application.Common.DTOs;
using Application.Common.Exceptions;
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

    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the categories.
    /// </returns>
    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
    {
        var categories = await _repository.CategoryRepository.GetAllCategoriesAsync(trackChanges);
        var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        return categoriesDto;
    }

    /// <summary>
    /// Gets a category by identifier.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the category.
    /// </returns>
    public async Task<CategoryDto?> GetCategoryByIdAsync(Guid categoryId, bool trackChanges)
    {
        var category = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
        
        if (category is null) 
            throw new CategoryNotFoundException(categoryId);

        var categoryDto = _mapper.Map<CategoryDto>(category);
        return categoryDto;
    }
}