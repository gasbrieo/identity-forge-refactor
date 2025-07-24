using IdentityForge.Infrastructure.IntegrationTests.TestHelpers.Persistence;
using IdentityForge.Infrastructure.Options;
using IdentityForge.Infrastructure.Persistence;

namespace IdentityForge.Infrastructure.IntegrationTests.Persistence;

[Collection(nameof(PersistenceTestCollection))]
public class AppDbContextInitialiserTests(PersistenceTestFixture fixture) : PersistenceTestBase(fixture)
{
    private readonly AppDbContext _context =
        fixture.GetRequiredService<AppDbContext>();

    private readonly AppDbContextInitialiser _initialiser =
        fixture.GetRequiredService<AppDbContextInitialiser>();

    private readonly AdminUserOptions _adminUser =
        fixture.GetRequiredService<IOptions<AdminUserOptions>>().Value;

    [Fact]
    public async Task InitialiseAsync_ThenAppliesPendingMigrations()
    {
        // Act
        await _initialiser.InitialiseAsync();

        // Assert 
        var tablesExist = await _context.Database.CanConnectAsync();
        Assert.True(tablesExist);
    }

    [Fact]
    public async Task SeedAsync_ThenCreatesAdminRoleAndUser()
    {
        // Act
        await _initialiser.SeedAsync();

        // Assert
        var adminRole = _context.Roles.FirstOrDefault(r => r.Name == _adminUser.Role);
        Assert.NotNull(adminRole);

        var adminUser = _context.Users.FirstOrDefault(u => u.Email == _adminUser.Email);
        Assert.NotNull(adminUser);
    }
}
