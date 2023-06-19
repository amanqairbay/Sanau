using Domain.Entities;

namespace Application.Repositories;

/// <summary>
/// Represents a category repository.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>Returns all categories.</returns>
    IEnumerable<Category> GetAllCategories(bool trackChanges);

    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the categories.
    /// </returns>
    Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);

    /// <summary>
    /// Gets a category by identifier.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// Returns a category.
    /// </returns>
    Category? GetCategoryById(Guid categoryId, bool trackChanges);

    /// <summary>
    /// Gets a category by identifier.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the category.
    /// </returns>
    Task<Category?> GetCategoryByIdAsync(Guid categoryId, bool trackChanges);
}