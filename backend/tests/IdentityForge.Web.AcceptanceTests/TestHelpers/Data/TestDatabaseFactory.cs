namespace IdentityForge.Web.AcceptanceTests.TestHelpers.Databases;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        var database = new PostgresTestDatabase();

        await database.InitialiseAsync();

        return database;
    }
}
