namespace IdentityForge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>((sp, opts) =>
        {
            opts.UseNpgsql(configuration.GetConnectionString("DefaultConnection")).AddAsyncSeeding(sp);
        });

        services.AddScoped<AppDbContextInitialiser>();

        services
            .AddHealthChecks()
            .AddDbContextCheck<AppDbContext>("Database");

        return services;
    }
}
