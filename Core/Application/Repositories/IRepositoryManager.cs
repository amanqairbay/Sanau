namespace Application.Repositories;

public interface IRepositoryManager
{
    /// <summary>
    /// Gets a brand repository.
    /// </summary>
    IBrandRepository BrandRepository { get; }

    /// <summary>
    /// Gets a category repository.
    /// </summary>
    ICategoryRepository CategoryRepository { get; } 

    /// <summary>
    /// Gets a product repository.
    /// </summary>
    IProductRepository ProductRepository { get; }    

    /// <summary>
    /// Saves all changes made in this repository to the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task SaveAsync();
}