namespace IdentityForge.Web.Extensions;

public static class CorsExtensions
{
    private const string SpaPolicyName = "SpaCorsPolicy";

    public static IServiceCollection AddSpaCors(this IServiceCollection services, IConfiguration configuration)
    {
        var allowedOrigins = configuration
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>();

        if (allowedOrigins is null || allowedOrigins.Length == 0)
            throw new InvalidOperationException("No allowed origins configured. Please set 'Cors:AllowedOrigins' in appsettings.");

        services.AddCors(options =>
        {
            options.AddPolicy(SpaPolicyName, policy =>
            {
                policy
                    .WithOrigins(allowedOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("WWW-Authenticate");
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSpaCors(this IApplicationBuilder app)
    {
        app.UseCors(SpaPolicyName);

        return app;
    }
}
