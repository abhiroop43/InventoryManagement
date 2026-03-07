using System.Reflection;

namespace IMS.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options),
        IApplicationDbContext
{
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<ApplicationUserRole> ApplicationUserRoles => Set<ApplicationUserRole>();
    public DbSet<UserRoleMapping> UserRoleMappings => Set<UserRoleMapping>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ims");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
