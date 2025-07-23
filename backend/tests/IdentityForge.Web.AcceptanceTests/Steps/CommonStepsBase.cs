using CleanArch;
using IdentityForge.Web.AcceptanceTests.TestHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    public async Task ThenTheResponseShouldBeProblemDetails()
    {
        Assert.NotNull(HttpResponse);

        var problem = await HttpResponse.Content.ReadFromJsonAsync<ProblemDetails>();
        Assert.NotNull(problem);
    }

    public async Task ThenTheResponseShouldBeValidationProblemDetails(Dictionary<string, string[]> errors)
    {
        Assert.NotNull(HttpResponse);

        var problem = await HttpResponse.Content.ReadFromJsonAsync<ValidationProblemDetails>();
        Assert.NotNull(problem);

        Assert.NotEmpty(problem.Errors);
        Assert.Equal(errors, problem.Errors);

        Assert.Null(problem.Detail);
        Assert.Null(problem.Instance);
        Assert.Equal(StatusCodes.Status400BadRequest, problem.Status);
        Assert.Equal("One or more validation errors occurred", problem.Title);
        Assert.Equal("https://tools.ietf.org/html/rfc7231#section-6.5.1", problem.Type);
    }
}
