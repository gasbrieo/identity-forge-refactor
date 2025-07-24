using IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence.Data;

namespace IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence;

public class PersistenceTestFixture : IAsyncLifetime
{
    private ITestDatabase _database = null!;
    private ServiceCollectionFactory _factory = null!;

    public async Task InitializeAsync()
    {
        _database = await TestDatabaseFactory.CreateAsync();
        _factory = new ServiceCollectionFactory(_database.GetConnection());
    }

    public T GetRequiredService<T>() where T : class
    {
        return _factory.Services.GetRequiredService<T>();
    }

    public async Task ResetState()
    {
        await _database.ResetAsync();
    }

    public async Task DisposeAsync()
    {
        await _database.DisposeAsync();
    }
}

