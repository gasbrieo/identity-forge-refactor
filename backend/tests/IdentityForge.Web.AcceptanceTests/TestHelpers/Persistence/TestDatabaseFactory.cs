using IdentityForge.Web.AcceptanceTests.TestHelpers.Persistence.Databases;

namespace IdentityForge.Web.AcceptanceTests.TestHelpers.Persistence;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        var database = new PostgresTestDatabase();

        await database.InitialiseAsync();

        return database;
    }
}
