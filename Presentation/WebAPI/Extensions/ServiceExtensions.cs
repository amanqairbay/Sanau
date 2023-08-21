using System.Text;
using Application.Repositories;
using Application.Services;
using Domain.Entities.ConfigurationModelsж;
using Domain.Entities.Identity;
using Domain.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using Persistence.Logging;
using Persistence.Repositories;
using Persistence.Services;
using StackExchange.Redis;
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

    /* 
        If we want to host our application on IIS, 
        we need to configure an IIS integration 
        which will eventually help us with the deployment to IIS.
    */
    public static void AddConfigureIISIntegration(this IServiceCollection services) => 
        services.Configure<IISOptions>(options => { });
    
    public static void AddConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();
    
    public static void AddConfigureRepositoryManager(this IServiceCollection services) => 
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void AddConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();
    
    public static void AddConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddSqlServer<DataContext>(configuration.GetConnectionString("SqlConnection"));

    public static void AddConfigureIdentityDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddSqlServer<AppIdentityDbContext>(configuration.GetConnectionString("IdentityConnection"));

    public static void AddConfigureAuthentication(this IServiceCollection services) =>
        services.AddAuthentication();

    public static void AddConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<AppUser, IdentityRole>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<AppIdentityDbContext>()
        .AddDefaultTokenProviders();
    }

    public static void AddConfigureRedis(this IServiceCollection services, IConfiguration configuration) =>
        services.AddSingleton<IConnectionMultiplexer>(c =>
        {
            var configurationOptions = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis")!);
            return ConnectionMultiplexer.Connect(configurationOptions);
        });

    public static void AddConfigureAutoMapper(this IServiceCollection services) => 
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    public static void AddConfigureApiBehaviorOptions(this IServiceCollection services) => 
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

    public static void AddConfigureValidationFilterAttribute(this IServiceCollection services) => 
        services.AddScoped<ValidationFilterAttribute>();

    public static void AddConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfiguration = new JwtConfiguration();
        configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

        var secretKey = jwtConfiguration.SecretKey;

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConfiguration.ValidIssuer,
                ValidAudience = jwtConfiguration.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });
    }

    public static void AddConfigureControllers(this IServiceCollection services) => 
        services.AddControllers(options =>
        {
            options.RespectBrowserAcceptHeader = true;
            options.ReturnHttpNotAcceptable = true;
        })
        .AddXmlDataContractSerializerFormatters();
}