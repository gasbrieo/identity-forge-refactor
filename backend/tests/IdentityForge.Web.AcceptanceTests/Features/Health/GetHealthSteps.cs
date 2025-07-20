using IdentityForge.Web.AcceptanceTests.Steps;
using IdentityForge.Web.AcceptanceTests.TestHelpers;

namespace IdentityForge.Web.AcceptanceTests.Features.Health;

[Collection(nameof(TestCollection))]
public class GetHealthSteps(TestFixture fixture) : CommonStepsBase(fixture)
{
    public async Task WhenTheyAttemptToChecksHealth()
    {
        HttpResponse = await Fixture.Client.GetAsync("/api/health");
    }
}
