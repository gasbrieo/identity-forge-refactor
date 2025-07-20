using IdentityForge.Web.AcceptanceTests.TestHelpers;

namespace IdentityForge.Web.AcceptanceTests.Steps;

public abstract class CommonStepsBase(TestFixture fixture)
{
    protected TestFixture Fixture = fixture;
    protected HttpResponseMessage? HttpResponse;

    public Task ThenTheResponseShouldBe200OK()
    {
        Assert.NotNull(HttpResponse);
        Assert.Equal(HttpStatusCode.OK, HttpResponse.StatusCode);
        return Task.CompletedTask;
    }

    public Task ThenTheResponseShouldBe201Created()
    {
        Assert.NotNull(HttpResponse);
        Assert.Equal(HttpStatusCode.Created, HttpResponse.StatusCode);
        return Task.CompletedTask;
    }

    public Task ThenTheResponseShouldBe204NoContent()
    {
        Assert.NotNull(HttpResponse);
        Assert.Equal(HttpStatusCode.NoContent, HttpResponse.StatusCode);
        return Task.CompletedTask;
    }

    public Task ThenTheResponseShouldBe400BadRequest()
    {
        Assert.NotNull(HttpResponse);
        Assert.Equal(HttpStatusCode.BadRequest, HttpResponse.StatusCode);
        return Task.CompletedTask;
    }

    public Task ThenTheResponseShouldBe401Unauthorized()
    {
        Assert.NotNull(HttpResponse);
        Assert.Equal(HttpStatusCode.Unauthorized, HttpResponse.StatusCode);
        return Task.CompletedTask;
    }

    public Task ThenTheResponseShouldBe403Forbidden()
    {
        Assert.NotNull(HttpResponse);
        Assert.Equal(HttpStatusCode.Forbidden, HttpResponse.StatusCode);
        return Task.CompletedTask;
    }

    public Task ThenTheResponseShouldBe404NotFound()
    {
        Assert.NotNull(HttpResponse);
        Assert.Equal(HttpStatusCode.NotFound, HttpResponse.StatusCode);
        return Task.CompletedTask;
    }
}
