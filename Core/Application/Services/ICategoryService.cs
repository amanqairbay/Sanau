using Application.Common.DTOs;

namespace Application.Services;

/// <summary>
/// Represents a category service.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the categories.
    /// </returns>
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);

    /// <summary>
    /// Gets a category by identifier.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the category.
    /// </returns>
    Task<CategoryDto?> GetCategoryByIdAsync(Guid categoryId, bool trackChanges);
}