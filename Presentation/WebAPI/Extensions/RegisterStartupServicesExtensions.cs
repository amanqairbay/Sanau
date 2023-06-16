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
        
        builder.Services.ConfigureCors();
        builder.Services.ConfigureIISIntegration();
        builder.Services.ConfigureLoggerService();
        builder.Services.ConfigureRepositoryManager();
        builder.Services.ConfigureServiceManager();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
        return builder;
    }
}