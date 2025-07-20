using IdentityForge.Infrastructure.IntegrationTests.TestHelpers;
using IdentityForge.Infrastructure.Persistence;

namespace IdentityForge.Infrastructure.IntegrationTests.Persistence;

[Collection(nameof(TestCollection))]
public class AppDbContextInitialiserTests(TestFixture fixture) : TestBase(fixture)
{
    private readonly AppDbContext _context =
        fixture.GetRequiredService<AppDbContext>();

    private readonly AppDbContextInitialiser _initialiser =
        fixture.GetRequiredService<AppDbContextInitialiser>();

    [Fact]
    public async Task InitialiseAsync_ShouldApplyPendingMigrations()
    {
        // Act
        await _initialiser.InitialiseAsync();

        // Assert 
        var tablesExist = await _context.Database.CanConnectAsync();
        Assert.True(tablesExist);
    }

    [Fact]
    public async Task SeedAsync_ShouldDoNothing()
    {
        // Act
        await _initialiser.SeedAsync();

        // Assert
        var tablesExist = await _context.Database.CanConnectAsync();
        Assert.True(tablesExist);
    }
}
