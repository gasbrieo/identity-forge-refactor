namespace IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence.Data;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        var database = new PostgresTestDatabase();

        await database.InitialiseAsync();

        return database;
    }
}
