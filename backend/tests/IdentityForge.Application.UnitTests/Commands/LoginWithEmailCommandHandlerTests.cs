using IdentityForge.Application.Commands.LoginWithEmail;
using IdentityForge.Application.Interfaces;
using IdentityForge.Domain.Entities;
using IdentityForge.Domain.Interfaces;

namespace IdentityForge.Application.UnitTests.Commands;

public class LoginWithEmailCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<ITokenProvider> _tokenProviderMock;
    private readonly LoginWithEmailCommandHandler _handler;

    public LoginWithEmailCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _tokenProviderMock = new Mock<ITokenProvider>();
        _handler = new LoginWithEmailCommandHandler(_userRepositoryMock.Object, _tokenProviderMock.Object);
    }

    [Fact]
    public async Task HandleAsync_WhenUserExists_ThenReturnsAuthResponse()
    {
        // Arrange
        var command = new LoginWithEmailCommand("admin@identityforge.com");
        var user = new User(command.Email);
        var accessToken = "valid.jwt.token";

        _userRepositoryMock
            .Setup(x => x.GetByEmailAsync(command.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        _tokenProviderMock
            .Setup(x => x.CreateAccessToken(user))
            .Returns(accessToken);

        // Act
        var result = await _handler.HandleAsync(command);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(accessToken, result.Value.Token.AccessToken);

        _userRepositoryMock.Verify(x => x.GetByEmailAsync(command.Email, It.IsAny<CancellationToken>()), Times.Once);
        _tokenProviderMock.Verify(x => x.CreateAccessToken(user), Times.Once);

        _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Never);
        _userRepositoryMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task HandleAsync_WhenUserNotExists_ThenCreatesAndReturnsAuthResponse()
    {
        // Arrange
        var command = new LoginWithEmailCommand("admin@identityforge.com");
        var accessToken = "valid.jwt.token";

        _tokenProviderMock
            .Setup(x => x.CreateAccessToken(It.IsAny<User>()))
            .Returns(accessToken);

        // Act
        var result = await _handler.HandleAsync(command);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(accessToken, result.Value.Token.AccessToken);

        _userRepositoryMock.Verify(x => x.GetByEmailAsync(command.Email, It.IsAny<CancellationToken>()), Times.Once);
        _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
        _userRepositoryMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        _tokenProviderMock.Verify(x => x.CreateAccessToken(It.IsAny<User>()), Times.Once);
    }
}
