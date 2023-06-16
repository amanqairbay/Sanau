using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

/// <summary>
/// Represents the brand repository class.
/// </summary>
public class BrandRepository : BaseRepository<Brand>, IBrandRepository
{
    public BrandRepository(DataContext context) : base(context)
    {
        
    }
}