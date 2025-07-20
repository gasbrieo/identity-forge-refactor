using IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence.Databases;

namespace IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        var database = new PostgresTestDatabase();

        await database.InitialiseAsync();

        return database;
    }
}
