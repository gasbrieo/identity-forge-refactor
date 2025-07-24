using IdentityForge.Domain.Entities;

namespace IdentityForge.Infrastructure.Persistence.Configs;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasMany(u => u.Roles)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                j => j.HasOne<Role>()
                      .WithMany()
                      .HasForeignKey("RoleId")
                      .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<User>()
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("RoleId", "UserId");
                }
            );

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}
