namespace IdentityForge.Domain.Entities;

public class User(string email) : BaseEntity
{
    public string Email { get; private set; } = email;


    private readonly List<Role> _roles = [];
    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

    public void AssignRole(Role role)
    {
        if (!HasRole(role))
            _roles.Add(role);
    }

    public bool HasRole(Role role)
    {
        return _roles.Any(r => r.Name == role.Name);
    }

    public IEnumerable<string> GetPermissionCodes()
    {
        return _roles
            .SelectMany(r => r.Permissions)
            .GroupBy(p => p.Code)
            .Select(g => g.First().Code);
    }
}
