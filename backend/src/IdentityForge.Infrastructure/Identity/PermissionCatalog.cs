namespace IdentityForge.Infrastructure.Identity;

public static class PermissionCatalog
{
    public static readonly PermissionDefinition CanListUsers = new("users.list");
    public static readonly PermissionDefinition CanGetUserById = new("users.get_by_id");
    public static readonly PermissionDefinition CanCreateUser = new("users.create");
    public static readonly PermissionDefinition CanUpdateUserLockout = new("users.update_lockout");
    public static readonly PermissionDefinition CanUpdateUserRoles = new("users.update_roles");
    public static readonly PermissionDefinition CanUpdateUserPassword = new("users.update_password");
    public static readonly PermissionDefinition CanDeleteUser = new("users.delete");

    public static readonly IReadOnlyList<PermissionDefinition> All =
    [
        CanListUsers,
        CanGetUserById,
        CanCreateUser,
        CanUpdateUserLockout,
        CanUpdateUserRoles,
        CanUpdateUserPassword,
        CanDeleteUser
    ];
}
