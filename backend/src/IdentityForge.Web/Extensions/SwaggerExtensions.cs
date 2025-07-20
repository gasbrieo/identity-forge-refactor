namespace IdentityForge.Web.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddOpenApiDocument(document =>
        {
            document.Title = "IdentityForge.V1";
            document.DocumentName = "v1";
            document.Version = "v1";
            document.ApiGroupNames = ["v1"];

            document.AddSecurity("Bearer", [], new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Type = OpenApiSecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerWithUi(this IApplicationBuilder app)
    {
        app.UseOpenApi(settings => settings.Path = "/api/specification.json");

        app.UseSwaggerUi(settings =>
        {
            settings.Path = "/api";
            settings.DocumentPath = "/api/specification.json";
        });

        app.UseReDoc(settings =>
        {
            settings.Path = "/docs";
            settings.DocumentPath = "/api/specification.json";
        });

        return app;
    }
}
