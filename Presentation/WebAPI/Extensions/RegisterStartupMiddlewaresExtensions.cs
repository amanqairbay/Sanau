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
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            
        }

        app.UseHttpsRedirection();
        
        // UseForwardedHeaders() will forward proxy headers to the current request. 
        // This will help us during application deployment.
        app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
        app.UseCors("CorsPolicy");
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}