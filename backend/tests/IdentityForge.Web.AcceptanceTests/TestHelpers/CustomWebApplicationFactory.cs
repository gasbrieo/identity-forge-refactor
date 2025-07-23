using IdentityForge.Infrastructure.Persistence;

namespace IdentityForge.Web.AcceptanceTests.TestHelpers;

public class CustomWebApplicationFactory(DbConnection connection) : WebApplicationFactory<IWebMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("Jwt:Secret", Guid.NewGuid().ToString());

        builder.ConfigureTestServices(services =>
        {
            services
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
        });
    }
}
