namespace IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence;

public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    string GetConnectionString();

    Task ResetAsync();

    Task DisposeAsync();
}
