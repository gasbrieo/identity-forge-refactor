using IdentityForge.Application.Interfaces;
using IdentityForge.Domain.Interfaces;
using IdentityForge.Infrastructure.Identity;
using IdentityForge.Infrastructure.Options;
using IdentityForge.Infrastructure.Persistence.Repositories;

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

        services
            .AddOptions<AdminUserOptions>()
            .Bind(configuration.GetSection("AdminUser"))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<AdminUserOptions>, AdminUserOptionsValidator>();

        services
            .AddOptions<JwtOptions>()
            .Bind(configuration.GetSection("Jwt"))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<JwtOptions>, JwtOptionsValidator>();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var jwt = configuration.GetSection("Jwt").Get<JwtOptions>()!;

                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Secret)),
                    ValidIssuer = jwt.Issuer,
                    ValidAudience = jwt.Audience,
                    ClockSkew = TimeSpan.Zero
                };
            });

        services.AddAuthorization(options =>
        {
            foreach (var permission in PermissionCatalog.All)
            {
                options.AddPolicy(permission.Code, policy =>
                    policy.RequireClaim("permission", permission.Code));
            }
        });

        services.AddSingleton<ITokenProvider, TokenProvider>();

        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }
}
