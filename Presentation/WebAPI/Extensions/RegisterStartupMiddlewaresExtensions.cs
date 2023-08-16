using Domain.Logging;
using Microsoft.AspNetCore.HttpOverrides;

namespace WebAPI.Extensions;

/// <summary>
/// Represents the startup middlewares register.
/// </summary>
public static class RegisterStartupMiddlewaresExtensions
{
    /// <summary>
    /// Configures middleware.
    /// </summary>
    /// <param name="app">The web application used to configure the HTTP pipeline, and routes.</param>
    /// <returns>
    /// Returns a configured WebApplication.
    /// </returns>
    public static WebApplication SetupMiddleware(this WebApplication app)
    {
        var logger = app.Services.GetRequiredService<ILoggerManager>();
        app.ConfigureExceptionHandler(logger);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseHsts();
        }

        app.UseStaticFiles();
        app.UseHttpsRedirection();
        
        /* 
            UseForwardedHeaders() will forward proxy headers to the current request. 
            This will help us during application deployment.
        */
        app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
        app.UseCors("CorsPolicy");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseConfigureSwagger();
        app.MapControllers();
        app.MigrateDatabase();
        
        return app;
    }
}