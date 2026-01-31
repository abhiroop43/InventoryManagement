using IMS.Core.Pagination;
using IMS.UseCases.Data;
using Microsoft.EntityFrameworkCore;

namespace IMS.UseCases.Inventory.Queries.GetInventories;

public class GetInventoriesQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetInventoriesQuery, GetInventoriesQueryResult>
{
    public async Task<GetInventoriesQueryResult> Handle(
        GetInventoriesQuery request,
        CancellationToken cancellationToken
    )
    {
        var totalInventory = await dbContext.Inventories.LongCountAsync(cancellationToken);
        var inventories = await dbContext
            .Inventories.AsNoTracking()
            .OrderByDescending(x => x.UpdatedDate)
            .Skip(request.PaginationRequest.PageIndex * request.PaginationRequest.PageSize)
            .Take(request.PaginationRequest.PageSize)
            .ToListAsync(cancellationToken);

        var mappedInventories = inventories.Adapt<List<InventoryDto>>();

        var paginatedInventories = new PaginatedResult<InventoryDto>(
            request.PaginationRequest.PageIndex,
            request.PaginationRequest.PageSize,
            totalInventory,
            mappedInventories
        );

        return new GetInventoriesQueryResult(paginatedInventories);
    }
}
