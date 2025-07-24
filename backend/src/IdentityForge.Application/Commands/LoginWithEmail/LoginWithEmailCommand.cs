using IdentityForge.Application.Models;

namespace IdentityForge.Application.Commands.LoginWithEmail;

public record LoginWithEmailCommand(string Email) : ICommand<AuthResponse>;
