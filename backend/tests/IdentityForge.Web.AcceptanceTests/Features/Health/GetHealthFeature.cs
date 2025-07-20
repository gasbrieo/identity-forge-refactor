using IdentityForge.Web.AcceptanceTests.TestHelpers;

namespace IdentityForge.Web.AcceptanceTests.Features.Health;

[Collection("TestCollection")]
public class GetHealthFeature(TestFixture fixture) : TestBase(fixture)
{
    private readonly GetHealthSteps _steps = new(fixture);

    [Fact]
    public async Task AnonymousUserChecksHealth()
    {
        await _steps.WhenTheyAttemptToChecksHealth();
        await _steps.ThenTheResponseShouldBe200OK();
    }
}
