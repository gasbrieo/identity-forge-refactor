using IdentityForge.Infrastructure.Persistence;
using IdentityForge.Web.AcceptanceTests.TestHelpers.Persistence;

namespace IdentityForge.Web.AcceptanceTests.TestHelpers;

public class TestFixture : IAsyncLifetime
{
    private ITestDatabase _database = null!;
    private CustomWebApplicationFactory _factory = null!;
    private IServiceScopeFactory _scopeFactory = null!;

    public HttpClient Client { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        _database = await TestDatabaseFactory.CreateAsync();
        _factory = new CustomWebApplicationFactory(_database.GetConnection());
        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();

        Client = _factory.CreateClient();
    }

    public async Task ResetState()
    {
        await _database.ResetAsync();

        using var scope = _scopeFactory.CreateScope();
        var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();
        await initialiser.SeedAsync();
    }

    public async Task DisposeAsync()
    {
        await _database.DisposeAsync();
        await _factory.DisposeAsync();
    }
}
