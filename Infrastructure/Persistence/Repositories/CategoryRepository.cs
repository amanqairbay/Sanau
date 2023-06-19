using Application.Repositories;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

/// <summary>
/// Represents the category repository class.
/// </summary>
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DataContext context) : base(context)
    {
        
    }        

    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>Returns all categories.</returns>
    public IEnumerable<Category> GetAllCategories(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the categories.
    /// </returns>
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();
    
    /// <summary>
    /// Gets a category.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// Returns a category.
    /// </returns>
    public Category? GetCategoryById(Guid categoryId, bool trackChanges) => 
        FindByCondition(c => c.Id.Equals(categoryId), trackChanges)
        .SingleOrDefault();

    /// <summary>
    /// Gets a category by identifier.
    /// </summary>
    /// <param name="categoryId">Category identifier.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the category.
    /// </returns>
    public async Task<Category?> GetCategoryByIdAsync(Guid categoryId, bool trackChanges) =>
        await FindByCondition(b => b.Id.Equals(categoryId), trackChanges)
            .SingleOrDefaultAsync();
}