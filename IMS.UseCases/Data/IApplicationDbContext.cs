using Microsoft.EntityFrameworkCore;

namespace IMS.UseCases.Data;

public interface IApplicationDbContext
{
    DbSet<Core.Models.Inventory> Inventories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}