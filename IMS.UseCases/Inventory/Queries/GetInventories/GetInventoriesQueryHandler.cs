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
        var totalInventory = await dbContext.Inventories.LongCountAsync(cancellationToken);
        var inventories = await dbContext
            .Inventories.AsNoTracking()
            .OrderByDescending(x => x.UpdatedDate)
            .Skip(query.PaginationRequest.PageIndex * query.PaginationRequest.PageSize)
            .Take(query.PaginationRequest.PageSize)
            .ToListAsync(cancellationToken);

        TypeAdapterConfig<Core.Models.Inventory, InventoryDto>
            .NewConfig()
            .Map(dest => dest.InventoryName, src => src.ItemName.Value)
            .Map(dest => dest.InventoryId, src => src.Id.Value);

        var mappedInventories = inventories.Adapt<List<InventoryDto>>();

        var paginatedInventories = new PaginatedResult<InventoryDto>(
            query.PaginationRequest.PageIndex,
            query.PaginationRequest.PageSize,
            totalInventory,
            mappedInventories
        );

        return new GetInventoriesQueryResult(paginatedInventories);
    }
}
