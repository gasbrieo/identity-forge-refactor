using IdentityForge.Domain.Entities;
using IdentityForge.Infrastructure.Options;

namespace IdentityForge.Infrastructure.Persistence;

public class AppDbContextInitialiser(
    ILogger<AppDbContextInitialiser> logger,
    IOptions<AdminUserOptions> adminUserOptions,
    AppDbContext context)
{
    private readonly AdminUserOptions _adminUserOptions = adminUserOptions.Value;

    public async Task InitialiseAsync()
    {
        try
        {
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        var adminRole = await context.Roles
            .Include(r => r.Permissions)
            .FirstOrDefaultAsync(r => r.Name == _adminUserOptions.Role);

        if (adminRole is null)
        {
            adminRole = new Role(_adminUserOptions.Role);
            await context.Roles.AddAsync(adminRole);
        }

        foreach (var permission in await context.Permissions.ToListAsync())
        {
            adminRole.AssignPermission(permission);
        }

        var adminUser = await context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Email == _adminUserOptions.Email);

        if (adminUser is null)
        {
            adminUser = new User(_adminUserOptions.Email);
            await context.Users.AddAsync(adminUser);
        }

        adminUser.AssignRole(adminRole);

        await context.SaveChangesAsync();
    }
}
