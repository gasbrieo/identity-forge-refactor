namespace IdentityForge.Domain.Entities;

public class Permission(string code) : BaseEntity
{
    public string Code { get; private set; } = code;
}
