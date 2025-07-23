namespace IdentityForge.Infrastructure.Options;

public class AdminUserOptions
{
    public string Email { get; set; } = default!;
    public string Role { get; set; } = default!;
}

public class AdminUserOptionsValidator : IValidateOptions<AdminUserOptions>
{
    public ValidateOptionsResult Validate(string? name, AdminUserOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.Email))
            return ValidateOptionsResult.Fail("Admin user email not configured");

        if (string.IsNullOrWhiteSpace(options.Role))
            return ValidateOptionsResult.Fail("Admin user role not configured");

        return ValidateOptionsResult.Success;
    }
}
