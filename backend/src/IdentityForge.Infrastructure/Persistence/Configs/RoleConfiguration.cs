using IdentityForge.Domain.Entities;

namespace IdentityForge.Infrastructure.Persistence.Configs;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.HasMany(u => u.Permissions)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "RolePermission",
                j => j.HasOne<Permission>()
                      .WithMany()
                      .HasForeignKey("PermissionId")
                      .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Role>()
                      .WithMany()
                      .HasForeignKey("RoleId")
                      .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("PermissionId", "RoleId");
                }
            );

        builder.HasIndex(r => r.Name)
            .IsUnique();
    }
}
