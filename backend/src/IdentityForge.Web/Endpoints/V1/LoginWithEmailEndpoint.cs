using IdentityForge.Application.Commands.LoginWithEmail;
using IdentityForge.Application.Models;

namespace IdentityForge.Web.Endpoints.V1;

public class LoginWithEmailEndpoint : IEndpointV1
{
    public record Request(string Email);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("login-with-email", async (
            Request request,
            ICommandHandler<LoginWithEmailCommand, AuthResponse> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new LoginWithEmailCommand(request.Email);

            var result = await handler.HandleAsync(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        });
    }
}
