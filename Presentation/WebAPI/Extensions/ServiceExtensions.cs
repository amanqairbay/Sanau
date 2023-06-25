using System.Reflection;
using Application.Repositories;
using Application.Services;
using Domain.Logging;
using Microsoft.AspNetCore.Mvc;
using Persistence.Context;
using Persistence.Logging;
using Persistence.Repositories;
using Persistence.Services;
using WebAPI.ActionFilters;

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
    public static void AddConfigureCors(this IServiceCollection services) => 
        services.AddCors(options => {
            options.AddPolicy("CorsPolicy", builder => 
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"));
        });

    // If we want to host our application on IIS, 
    // we need to configure an IIS integration 
    // which will eventually help us with the deployment to IIS.
    public static void AddConfigureIISIntegration(this IServiceCollection services) => 
        services.Configure<IISOptions>(options => {});
    
    public static void AddConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();
    
    public static void AddConfigureRepositoryManager(this IServiceCollection services) => 
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void AddConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();
    
    public static void AddConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddSqlServer<DataContext>((configuration.GetConnectionString("sqlConnection")));

    public static void AddConfigureAutoMapper(this IServiceCollection services) => 
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    public static void AddConfigureApiBehaviorOptions(this IServiceCollection services) => 
        services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

    public static void AddConfigureValidationFilterAttribute(this IServiceCollection services) => 
        services.AddScoped<ValidationFilterAttribute>();

    public static void AddConfigureControllers(this IServiceCollection services) => 
        services.AddControllers(config => {
            config.RespectBrowserAcceptHeader = true;
            config.ReturnHttpNotAcceptable = true;
        }).AddXmlDataContractSerializerFormatters();
}