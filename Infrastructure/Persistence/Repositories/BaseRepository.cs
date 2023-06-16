using System.Linq.Expressions;
using Application.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

/// <summary>
/// Represents the base repository class.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected DataContext _dataContext;

    public BaseRepository(DataContext dataContext) => _dataContext = dataContext;

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
    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges 
        ? _dataContext.Set<T>().AsNoTracking() 
        : _dataContext.Set<T>();

    /// <summary>
    /// Finds entity entries by condition.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="expression">A function to test each element for a condition.</param>
    /// <param name="trackChanges">Used to improve the performance of read-only queries. When it is set to false, 
    /// the AsNoTracking method is connected to the request to inform EF Core 
    /// that it does not need to track changes for the required objects. 
    /// This greatly improves the speed of query execution.
    /// </param>
    /// <returns>Entity entries</returns>
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) 
        => !trackChanges 
            ? _dataContext.Set<T>().Where(expression).AsNoTracking() 
            : _dataContext.Set<T>().Where(expression);

    /// <summary>
    /// Create the entity entry.
    /// </summary>
    /// <param name="entity">Entity entry.</param>
    public void Create(T entity) => _dataContext.Set<T>().Add(entity);

    /// <summary>
    /// Update the entity entry.
    /// </summary>
    /// <param name="entity">Entity entry.</param>
    public void Update(T entity) => _dataContext.Set<T>().Update(entity);

    /// <summary>
    /// Delete the entity entry.
    /// </summary>
    /// <param name="entity">Entity entry.</param>
    public void Delete(T entity) => _dataContext.Set<T>().Remove(entity);
}