namespace IdentityForge.Application.Commands.LoginWithEmail;

public class LoginWithEmailCommandValidator : AbstractValidator<LoginWithEmailCommand>
{
    public LoginWithEmailCommandValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress();
    }
}
