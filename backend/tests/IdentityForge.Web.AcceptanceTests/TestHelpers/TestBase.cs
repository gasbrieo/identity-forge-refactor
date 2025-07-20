namespace IdentityForge.Web.AcceptanceTests.TestHelpers;

public abstract class TestBase(TestFixture fixture) : IAsyncLifetime
{
    protected readonly TestFixture Fixture = fixture;

    public async Task InitializeAsync()
    {
        await Fixture.ResetState();
    }

    public Task DisposeAsync() => Task.CompletedTask;
}
