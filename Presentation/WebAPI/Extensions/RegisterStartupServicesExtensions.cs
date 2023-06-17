using NLog;

namespace WebAPI.Extensions;

public static class RegisterStartupServicesExtensions
{
    /// <summary>
    /// Registers services.
    /// </summary>
    /// <param name="builder">A builder for web applications and services.</param>
    /// <returns>
    /// Returns a configured WebApplicationBuilder.
    /// </returns>
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        var configuration = builder.Configuration;
        
        builder.Services.AddConfigureCors();
        builder.Services.AddConfigureIISIntegration();
        builder.Services.AddConfigureLoggerService();
        builder.Services.AddConfigureRepositoryManager();
        builder.Services.AddConfigureServiceManager();
        builder.Services.AddConfigureSqlContext(configuration);
        builder.Services.AddConfigureAutoMapper();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
        return builder;
    }
}