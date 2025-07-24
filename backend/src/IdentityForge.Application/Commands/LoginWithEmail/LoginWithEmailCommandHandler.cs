using IdentityForge.Application.Interfaces;
using IdentityForge.Application.Models;
using IdentityForge.Domain.Entities;
using IdentityForge.Domain.Interfaces;

namespace IdentityForge.Application.Commands.LoginWithEmail;

public class LoginWithEmailCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider) : ICommandHandler<LoginWithEmailCommand, AuthResponse>
{
    public async Task<Result<AuthResponse>> HandleAsync(LoginWithEmailCommand command, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByEmailAsync(command.Email, cancellationToken);

        if (user is null)
        {
            user = new User(command.Email);
            await userRepository.AddAsync(user, cancellationToken);
            await userRepository.SaveChangesAsync(cancellationToken);
        }

        var token = tokenProvider.CreateAccessToken(user);

        return new AuthResponse(new(user.Email), new(token));
    }
}
