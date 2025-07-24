using IdentityForge.Domain.Entities;

namespace IdentityForge.Domain.UnitTests.Entities;

public class UserTests
{
    [Fact]
    public void Constructor_ThenInstantiate()
    {
        // Arrange
        var email = "admin@identityforge.com";

        // Act
        var user = new User(email);

        // Assert
        Assert.Equal(email, user.Email);
    }

    [Fact]
    public void AssignRole_WhenNotAssigned_ThenAssign()
    {
        // Arrange
        var user = new User("admin@identityforge.com");
        var roleAdmin = new Role("Admin");
        var roleViewer = new Role("Viewer");

        // Act
        user.AssignRole(roleAdmin);
        user.AssignRole(roleViewer);

        // Assert
        Assert.Equal(2, user.Roles.Count);
        Assert.Contains(roleAdmin, user.Roles);
        Assert.Contains(roleViewer, user.Roles);
    }

    [Fact]
    public void AssignRole_WhenAlreadyAssigned_ThenNotDuplicate()
    {
        // Arrange
        var user = new User("admin@identityforge.com");

        var role = new Role("Admin");

        user.AssignRole(role);

        // Act
        user.AssignRole(role);

        // Assert
        Assert.Single(user.Roles);
        Assert.Contains(role, user.Roles);
    }

    [Fact]
    public void HasRole_WhenIsAssigned_ThenReturnsTrue()
    {
        // Arrange
        var user = new User("admin@identityforge.com");

        var role = new Role("Admin");

        user.AssignRole(role);

        // Act
        var result = user.HasRole(role);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasRole_WhenIsNotAssigned_ThenReturnsFalse()
    {
        // Arrange
        var user = new User("admin@identityforge.com");

        var assignedRole = new Role("Admin");
        var unassignedRole = new Role("Viewer");

        user.AssignRole(assignedRole);

        // Act
        var result = user.HasRole(unassignedRole);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetPermissionCodes_ThenReturnsPermissionCodes()
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
        var result = user.GetPermissionCodes();

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(permissionList.Code, result);
        Assert.Contains(permissionCreate.Code, result);
    }
}
