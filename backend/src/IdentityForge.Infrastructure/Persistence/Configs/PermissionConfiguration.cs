using IdentityForge.Domain.Entities;

namespace IdentityForge.Infrastructure.Persistence.Configs;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permission");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(128);

        builder.HasIndex(p => p.Code)
            .IsUnique();
    }
}
