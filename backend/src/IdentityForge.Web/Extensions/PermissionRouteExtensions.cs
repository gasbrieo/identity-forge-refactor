using IdentityForge.Infrastructure.Identity;

namespace IdentityForge.Web.Extensions;

public static class PermissionRouteExtensions
{
    public static RouteHandlerBuilder HasPermission(
        this RouteHandlerBuilder builder,
        PermissionDefinition permission)
    {
        return builder.RequireAuthorization(permission.Code);
    }
}
