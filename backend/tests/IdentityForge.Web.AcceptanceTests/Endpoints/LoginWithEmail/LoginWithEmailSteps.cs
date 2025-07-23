using IdentityForge.Application.Models;
using IdentityForge.Web.AcceptanceTests.Steps;
using IdentityForge.Web.AcceptanceTests.TestHelpers;
using IdentityForge.Web.Endpoints.V1;

namespace IdentityForge.Web.AcceptanceTests.Endpoints.LoginWithEmail;

public class LoginWithEmailSteps(TestFixture fixture) : CommonStepsBase(fixture)
{
    public async Task GivenAnExistingUser(string email)
    {
        await WhenTheyAttemptToLogin(email);
    }

    public async Task WhenTheyAttemptToLogin(string email)
    {
        var request = new LoginWithEmailEndpoint.Request(email);
        HttpResponse = await Fixture.Client.PostAsJsonAsync("/api/v1/login-with-email", request);
    }

    public async Task ThenTheResponseShouldContainUserAndToken()
    {
        var response = await HttpResponse!.Content.ReadFromJsonAsync<AuthResponse>();
        Assert.NotNull(response);
        Assert.False(string.IsNullOrEmpty(response.User.Email));
        Assert.False(string.IsNullOrEmpty(response.Token.AccessToken));
    }
}
