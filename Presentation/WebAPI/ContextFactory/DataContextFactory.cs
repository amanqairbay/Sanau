using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Context;

namespace WebAPI.ContextFactory;

// IDesignTimeDbContextFactory<out TContext> interface that allows design-time services 
// to discover implementations of this interface.

/// <summary>
/// This class will help this application create a derived DbContext instance during 
/// the design time which will help us with our migrations
/// </summary>
public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    /// <summary>
    /// Creates the database context.
    /// </summary>
    /// <param name="args">Arguments</param>
    /// <returns>
    /// Returns a new instance of the repository context class with the provided parameters.
    /// </returns>
    public DataContext CreateDbContext(string[] args) 
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(configuration.GetConnectionString("sqlConnection"));
        
        return new DataContext(builder.Options);
    }
}