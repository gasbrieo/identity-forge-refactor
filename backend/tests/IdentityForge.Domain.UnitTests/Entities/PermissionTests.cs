using IdentityForge.Domain.Entities;

namespace IdentityForge.Domain.UnitTests.Entities;

public class PermissionTests
{
    [Fact]
    public void Constructor_ThenInstantiate()
    {
        // Arrange
        var code = "users.list";

        // Act
        var permission = new Permission(code);

        // Assert
        Assert.Equal(code, permission.Code);
    }
}
