using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace WebAPI.Extensions;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();
        var services = scope.ServiceProvider;
        var identityContext = services.GetRequiredService<AppIdentityDbContext>();
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var logger = services.GetRequiredService<ILogger<AppIdentityDbContextSeed>>();

        try
        {
            identityContext.Database.Migrate();
            AppIdentityDbContextSeed.SeedUsers(userManager);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occured during  migration.");
        }

        return webApp;
    }
}