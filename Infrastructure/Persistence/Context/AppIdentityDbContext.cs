using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Identity.Configuration;

namespace Persistence.Context;

/// <summary>
/// Represents an application database context for identity.
/// </summary>
public class AppIdentityDbContext : IdentityDbContext<AppUser>
{
    #region constructor

    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    {
    }

    #endregion constructor

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}