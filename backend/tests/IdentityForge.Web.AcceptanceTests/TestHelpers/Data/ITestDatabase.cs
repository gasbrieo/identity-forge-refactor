namespace IdentityForge.Web.AcceptanceTests.TestHelpers.Databases;

public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    string GetConnectionString();

    Task ResetAsync();

    Task DisposeAsync();
}
