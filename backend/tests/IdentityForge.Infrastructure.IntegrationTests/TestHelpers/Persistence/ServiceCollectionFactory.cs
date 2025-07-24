using IdentityForge.Infrastructure.Persistence;

namespace IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence;

public class ServiceCollectionFactory
{
    public IServiceProvider Services { get; }

    public ServiceCollectionFactory(DbConnection connection)
    {
        var builder = new HostApplicationBuilder();

        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["AdminUser:Email"] = "admin@identityforge.com",
            ["AdminUser:Role"] = "Admin",
        });

        builder.Services.AddInfrastructure(builder.Configuration);

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

        Services = builder.Services.BuildServiceProvider();
    }
}
