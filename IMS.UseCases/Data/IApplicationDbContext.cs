using IMS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.UseCases.Data;

public interface IApplicationDbContext
{
    DbSet<Core.Models.Inventory> Inventories { get; }
    DbSet<Core.Models.ApplicationUser> ApplicationUsers { get; }
    DbSet<ApplicationUserRole> ApplicationUserRoles { get; }

    DbSet<UserRoleMapping> UserRoleMappings { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
