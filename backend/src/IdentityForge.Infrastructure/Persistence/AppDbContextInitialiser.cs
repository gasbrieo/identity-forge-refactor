namespace IdentityForge.Infrastructure.Persistence;

public class AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext context)
{
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

    public static Task TrySeedAsync()
    {
        return Task.CompletedTask;
    }
}
