using IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence;
using IdentityForge.Infrastructure.Persistence;

namespace IdentityForge.Infrastructure.IntegrationTests.TestHelpers;

public class TestFixture : IAsyncLifetime
{
    private ITestDatabase _database = null!;
    private ServiceCollectionFactory _factory = null!;
    private IServiceScopeFactory _scopeFactory = null!;

    public async Task InitializeAsync()
    {
        _database = await TestDatabaseFactory.CreateAsync();
        _factory = new ServiceCollectionFactory(_database.GetConnection());
        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
    }

    public T GetRequiredService<T>() where T : class
    {
        return _factory.Services.GetRequiredService<T>();
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
    }
}
