using IdentityForge.Web.AcceptanceTests.Steps;
using IdentityForge.Web.AcceptanceTests.TestHelpers;

namespace IdentityForge.Web.AcceptanceTests.Endpoints.Health;

public class GetHealthSteps(TestFixture fixture) : CommonStepsBase(fixture)
{
    public async Task WhenTheyAttemptToChecksHealth()
    {
        HttpResponse = await Fixture.Client.GetAsync("/api/health");
    }
}
