using IMS.Core.Pagination;
using IMS.UseCases.Data;
using Microsoft.EntityFrameworkCore;

namespace IMS.UseCases.Inventory.Queries.GetInventories;

public class GetInventoriesQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetInventoriesQuery, GetInventoriesQueryResult>
{
    public async Task<GetInventoriesQueryResult> Handle(
        GetInventoriesQuery query,
        CancellationToken cancellationToken
    )
    {
        var inventoryCountQuery = dbContext.Inventories.AsNoTracking();

        var inventories = dbContext
            .Inventories.AsNoTracking()
            .OrderByDescending(x => x.UpdatedDate)
            .Skip(query.PaginationRequest.PageIndex * query.PaginationRequest.PageSize)
            .Take(query.PaginationRequest.PageSize);

        if (!string.IsNullOrEmpty(query.InventoryName))
        {
            inventories = inventories.Where(x =>
                x.ItemName.Value.ToUpper().Contains(query.InventoryName.ToUpper())
            );
            inventoryCountQuery = inventoryCountQuery.Where(x =>
                x.ItemName.Value.ToUpper().Contains(query.InventoryName.ToUpper())
            );
        }

        if (query.CreatedDateFrom != null)
        {
            inventories = inventories.Where(x => x.CreatedDate >= query.CreatedDateFrom);
            inventoryCountQuery = inventoryCountQuery.Where(x =>
                x.CreatedDate >= query.CreatedDateFrom
            );
        }

        if (query.CreatedDateTo != null)
        {
            inventories = inventories.Where(x => x.CreatedDate <= query.CreatedDateTo);
            inventoryCountQuery = inventoryCountQuery.Where(x =>
                x.CreatedDate <= query.CreatedDateTo
            );
        }

        var finalizedInventories = await inventories.ToListAsync(cancellationToken);

        var totalInventory = await inventoryCountQuery.LongCountAsync(cancellationToken);

        TypeAdapterConfig<Core.Models.Inventory, InventoryDto>
            .NewConfig()
            .Map(dest => dest.InventoryName, src => src.ItemName.Value)
            .Map(dest => dest.InventoryId, src => src.Id.Value);

        var mappedInventories = finalizedInventories.Adapt<List<InventoryDto>>();

        var paginatedInventories = new PaginatedResult<InventoryDto>(
            query.PaginationRequest.PageIndex,
            query.PaginationRequest.PageSize,
            totalInventory,
            mappedInventories
        );

        return new GetInventoriesQueryResult(paginatedInventories);
    }
}
