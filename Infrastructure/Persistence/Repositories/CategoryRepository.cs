using Application.Repositories;

using Domain.Entities;
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
}