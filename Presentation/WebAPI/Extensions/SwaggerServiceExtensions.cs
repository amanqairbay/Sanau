using System.Reflection;
using Microsoft.OpenApi.Models;

namespace WebAPI.Extensions;

/// <summary>
/// Represents a Swagger documentation.
/// </summary>
public static class SwaggerServiceExtensions
{
    public static void AddConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Sanau API",
                Version = "v1",
                Description = "Sanau System API",
                TermsOfService = new Uri("https://sanau-system.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Aman Qairbay",
                    Email = "amanqairbay@gmail.com",
                    Url = new Uri("https://sanau-system.com/amanqairbay"),
                },
                License = new OpenApiLicense
                {
                    Name = "Sanau System API LICX",
                    Url = new Uri("https://example.com/license"),
                }
            });

            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Place to add JWT with Bearer",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Name = "Bearer",
                    },
                    new List<string>()
                }
            });

            var xmlFile = $"{typeof(Program).GetTypeInfo().Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            s.IncludeXmlComments(xmlPath);
        });
    }

    public static WebApplication UseConfigureSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sanau API v1"));

        return app;
    }
}