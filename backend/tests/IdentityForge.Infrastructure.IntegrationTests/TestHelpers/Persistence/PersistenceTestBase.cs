namespace IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence;

public abstract class PersistenceTestBase(PersistenceTestFixture fixture) : IAsyncLifetime
{
    protected readonly PersistenceTestFixture Fixture = fixture;

    public async Task InitializeAsync()
    {
        await Fixture.ResetState();
    }

    public Task DisposeAsync() => Task.CompletedTask;
}
