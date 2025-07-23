using IdentityForge.Web.AcceptanceTests.TestHelpers;

namespace IdentityForge.Web.AcceptanceTests.Endpoints.LoginWithEmail;

[Collection(nameof(TestCollection))]
public class LoginWithEmailFeature(TestFixture fixture) : TestBase(fixture)
{
    private readonly LoginWithEmailSteps _steps = new(fixture);

    [Fact]
    public async Task UserLogsInWithExistentEmail()
    {
        await _steps.GivenAnExistingUser("login@localhost");
        await _steps.WhenTheyAttemptToLogin("login@localhost");
        await _steps.ThenTheResponseShouldBe200OK();
        await _steps.ThenTheResponseShouldContainUserAndToken();
    }

    [Fact]
    public async Task UserLogsInWithNonExistentEmail()
    {
        await _steps.WhenTheyAttemptToLogin("login@localhost");
        await _steps.ThenTheResponseShouldBe200OK();
        await _steps.ThenTheResponseShouldContainUserAndToken();
    }

    [Fact]
    public async Task UserAttemptsToLoginWithEmptyEmail()
    {
        await _steps.WhenTheyAttemptToLogin(string.Empty);
        await _steps.ThenTheResponseShouldBe400BadRequest();
        await _steps.ThenTheResponseShouldBeValidationProblemDetails(new()
        {
            ["Email"] = ["'Email' is not a valid email address."]
        });
    }

    [Fact]
    public async Task UserAttemptsToLoginWithInvalidEmail()
    {
        await _steps.WhenTheyAttemptToLogin("login");
        await _steps.ThenTheResponseShouldBe400BadRequest();
        await _steps.ThenTheResponseShouldBeValidationProblemDetails(new()
        {
            ["Email"] = ["'Email' is not a valid email address."]
        });
    }
}
