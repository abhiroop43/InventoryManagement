using IMS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.UseCases.Data;

public interface IApplicationDbContext
{
    DbSet<Core.Models.Inventory> Inventories { get; }
    DbSet<ApplicationUser> ApplicationUsers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
