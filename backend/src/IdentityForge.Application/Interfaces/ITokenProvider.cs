using IdentityForge.Domain.Entities;

namespace IdentityForge.Application.Interfaces;

public interface ITokenProvider
{
    string CreateAccessToken(User user);
}
