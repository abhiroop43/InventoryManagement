using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IMS.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    /// <summary>
    /// Will check if any of the child entity linked through navigation property has changed.
    /// </summary>
    /// <param name="entry">the entity entry to check for child entity changes</param>
    /// <returns>true if any child entity has changed, otherwise false</returns>
    public static bool HasChangedOwnEntities(this EntityEntry entry)
    {
        return entry.References.Any(r =>
            r.TargetEntry != null
            && r.TargetEntry.Metadata.IsOwned()
            && r.TargetEntry.State is EntityState.Added or EntityState.Modified
        );
    }

    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.MigrateAsync();
        await SeedAsync(dbContext);
    }

    private static async Task SeedAsync(ApplicationDbContext dbContext)
    {
        await SeedInventoriesAsync(dbContext);
    }

    private static async Task SeedInventoriesAsync(ApplicationDbContext dbContext)
    {
        if (!await dbContext.Inventories.AnyAsync())
        {
            await dbContext.Inventories.AddRangeAsync(InitialData.Inventories);
            await dbContext.SaveChangesAsync();
        }
    }
}
