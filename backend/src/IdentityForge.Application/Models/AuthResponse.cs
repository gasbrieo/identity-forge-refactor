namespace IdentityForge.Application.Models;

public record AuthResponse(UserResponse User, TokenResponse Token);
