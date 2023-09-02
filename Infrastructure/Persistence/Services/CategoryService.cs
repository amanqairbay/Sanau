using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;

namespace Persistence.Services;

internal sealed class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CategoryService(
        IRepositoryManager repository,
        IMapper mapper)
    {
        _repository = repository;
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
    /// <exception cref="NotFoundException">Thrown if the category doesn't exist in the database.</exception>
    public async Task<CategoryDto?> GetCategoryByIdAsync(Guid categoryId, bool trackChanges)
    {
        var category = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
        
        if (category is null) 
            throw new NotFoundException($"The category with id: {categoryId} doesn't exist in the database.");

        var categoryDto = _mapper.Map<CategoryDto>(category);
        return categoryDto;
    }

    /// <summary>
    /// Creates a category.
    /// </summary>
    /// <param name="categoryForCreationDto">Category data transfer object for creation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the category.
    /// </returns>
    public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto)
    {
        var category = _mapper.Map<Category>(categoryForCreationDto);

        _repository.CategoryRepository.CreateCategory(category);
        await _repository.SaveAsync();

        var categoryDto = _mapper.Map<CategoryDto>(category);

        return categoryDto;
    }
}