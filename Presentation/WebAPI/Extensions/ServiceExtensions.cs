using Application.Repositories;
using Application.Services;
using Domain.Logging;
using Persistence.Logging;
using Persistence.Repositories;
using Persistence.Services;

namespace WebAPI.Extensions;

/// <summary>
/// Represents the service extensions.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// CORS (Cross-Origin Resource Sharing) is a mechanism to give or restrict access rights to applications from different domains.
    /// </summary>
    /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services to.</param>
    public static void ConfigureCors(this IServiceCollection services) => 
        services.AddCors(options => 
        {
            options.AddPolicy("CorsPolicy", builder => 
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

    // If we want to host our application on IIS, 
    // we need to configure an IIS integration 
    // which will eventually help us with the deployment to IIS.
    public static void ConfigureIISIntegration(this IServiceCollection services) => 
        services.Configure<IISOptions>(options => {});
    
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();
    
    public static void ConfigureRepositoryManager(this IServiceCollection services) => 
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
       services.AddScoped<IServiceManager, ServiceManager>();
}