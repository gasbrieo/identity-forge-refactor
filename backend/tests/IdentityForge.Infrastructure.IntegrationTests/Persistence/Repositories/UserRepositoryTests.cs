using IdentityForge.Domain.Entities;
using IdentityForge.Domain.Interfaces;
using IdentityForge.Infrastructure.IntegrationTests.TestHelpers;

namespace IdentityForge.Infrastructure.IntegrationTests.Persistence.Repositories;

[Collection(nameof(TestCollection))]
public class UserRepositoryTests(TestFixture fixture) : TestBase(fixture)
{
    private readonly IUserRepository _repository =
        fixture.GetRequiredService<IUserRepository>();

    [Fact]
    public async Task UserIsCreatedAndLoadedCorrectly()
    {
        // Arrange
        var user = new User("admin@identityforge.com");

        var permissionList = new Permission("users.list");
        var permissionCreate = new Permission("users.create");

        var roleAdmin = new Role("Admin");
        roleAdmin.AssignPermission(permissionList);
        roleAdmin.AssignPermission(permissionCreate);

        var roleViewer = new Role("Viewer");
        roleViewer.AssignPermission(permissionList);

        user.AssignRole(roleAdmin);
        user.AssignRole(roleViewer);

        // Act
        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();

        // Assert
        var retrieved = await _repository.GetByEmailAsync(user.Email);

        Assert.NotNull(retrieved);
        Assert.Equal(user.Email, retrieved.Email);

        Assert.Equal(2, retrieved.Roles.Count);
        Assert.Contains(roleAdmin, retrieved.Roles);
        Assert.Contains(roleViewer, retrieved.Roles);

        var permissionCodes = retrieved.GetPermissionCodes();

        Assert.Equal(2, permissionCodes.Count());
        Assert.Contains(permissionList.Code, permissionCodes);
        Assert.Contains(permissionCreate.Code, permissionCodes);
    }
}
