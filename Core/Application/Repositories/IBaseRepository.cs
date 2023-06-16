using System.Linq.Expressions;

namespace Application.Repositories;

/// <summary>
/// Represents a base repository interface.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public interface IBaseRepository<T>
{
    /// <summary>
    /// Finds all entity entries.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="trackChanges">
    /// Used to improve the performance of read-only queries. When it is set to false, 
    /// the AsNoTracking method is connected to the request to inform EF Core 
    /// that it does not need to track changes for the required objects. 
    /// This greatly improves the speed of query execution.
    /// </param>
    /// <returns>Entity entries.</returns>
    IQueryable<T> FindAll(bool trackChanges);

    /// <summary>
    /// Finds entity entries by condition.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="expression">A function to test each element for a condition.</param>
    /// <param name="trackChanges">
    /// Used to improve the performance of read-only queries. When it is set to false, 
    /// the AsNoTracking method is connected to the request to inform EF Core 
    /// that it does not need to track changes for the required objects. 
    /// This greatly improves the speed of query execution.
    /// </param>
    /// <returns>Entity entries.</returns>
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

    /// <summary>
    /// Create the entity entry.
    /// </summary>
    /// <param name="entity">Entity entry.</param>
    void Create(T entity);

    /// <summary>
    /// Update the entity entry.
    /// </summary>
    /// <param name="entity">Entity entry.</param>
    void Update(T entity);

    /// <summary>
    /// Delete the entity entry.
    /// </summary>
    /// <param name="entity">Entity entry.</param>
    void Delete(T entity);
}