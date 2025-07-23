namespace IdentityForge.Domain.Entities;

public class Role(string name) : BaseEntity
{
    public string Name { get; private set; } = name;


    private readonly List<Permission> _permissions = [];
    public IReadOnlyCollection<Permission> Permissions => _permissions.AsReadOnly();

    public void AssignPermission(Permission permission)
    {
        if (!HasPermission(permission))
            _permissions.Add(permission);
    }

    public bool HasPermission(Permission permission)
    {
        return _permissions.Any(p => p.Code == permission.Code);
    }
}
