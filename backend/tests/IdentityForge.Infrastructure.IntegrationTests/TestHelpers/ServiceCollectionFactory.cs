using IdentityForge.Infrastructure.Persistence;

namespace IdentityForge.Infrastructure.IntegrationTests.TestHelpers;

public class ServiceCollectionFactory
{
    public IServiceProvider Services { get; }

    public ServiceCollectionFactory(DbConnection connection)
    {
        var builder = new HostApplicationBuilder();

        builder.Services
            .RemoveAll<DbContextOptions<AppDbContext>>()
            .AddDbContext<AppDbContext>((sp, options) =>
            {
                if (connection is SqliteConnection)
                    options.UseSqlite(connection);
                else if (connection is NpgsqlConnection)
                    options.UseNpgsql(connection);
                else
                    throw new NotSupportedException("Unsupported DB connection type");

            });

        builder.Services.AddScoped<AppDbContextInitialiser>();

        Services = builder.Services.BuildServiceProvider();
    }
}
