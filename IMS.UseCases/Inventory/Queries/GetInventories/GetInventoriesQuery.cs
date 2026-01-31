using IMS.Core.Pagination;

namespace IMS.UseCases.Inventory.Queries.GetInventories;

public record GetInventoriesQuery(PaginationRequest PaginationRequest)
    : IQuery<GetInventoriesQueryResult>;

public record GetInventoriesQueryResult(PaginatedResult<InventoryDto> Inventories);
