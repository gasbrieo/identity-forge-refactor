namespace IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence.Data;

public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    string GetConnectionString();

    Task ResetAsync();

    Task DisposeAsync();
}
