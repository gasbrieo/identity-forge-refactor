using IdentityForge.Domain.Entities;

namespace IdentityForge.Domain.UnitTests.Entities;

public class RoleTests
{
    [Fact]
    public void Constructor_ThenInstantiate()
    {
        // Arrange
        var name = "Admin";

        // Act
        var role = new Role(name);

        // Assert
        Assert.Equal(name, role.Name);
    }

    [Fact]
    public void AssignPermission_WhenNotAssigned_ThenAssign()
    {
        // Arrange
        var role = new Role("Admin");
        var permissionList = new Permission("users.list");
        var permissionCreate = new Permission("users.create");

        // Act
        role.AssignPermission(permissionList);
        role.AssignPermission(permissionCreate);

        // Assert
        Assert.Equal(2, role.Permissions.Count);
        Assert.Contains(permissionList, role.Permissions);
        Assert.Contains(permissionCreate, role.Permissions);
    }

    [Fact]
    public void AssignPermission_WhenAlreadyAssigned_ThenNotDuplicate()
    {
        // Arrange
        var role = new Role("Admin");
        var permission = new Permission("users.list");

        role.AssignPermission(permission);

        // Act
        role.AssignPermission(permission);

        // Assert
        Assert.Single(role.Permissions);
        Assert.Contains(permission, role.Permissions);
    }

    [Fact]
    public void HasPermission_WhenIsAssigned_ThenReturnsTrue()
    {
        // Arrange
        var role = new Role("Admin");
        var permission = new Permission("users.list");

        role.AssignPermission(permission);

        // Act
        var result = role.HasPermission(permission);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasPermission_WhenIsNotAssigned_ThenReturnsFalse()
    {
        // Arrange
        var role = new Role("Admin");
        var assignedPermission = new Permission("users.list");
        var unassignedPermission = new Permission("users.create");

        role.AssignPermission(assignedPermission);

        // Act
        var result = role.HasPermission(unassignedPermission);

        // Assert
        Assert.False(result);
    }
}
