using IMS.Core.Pagination;

namespace IMS.UseCases.Inventory.Queries.GetInventories;

public record GetInventoriesQuery(
    PaginationRequest PaginationRequest,
    string? InventoryName,
    DateTime? CreatedDateFrom,
    DateTime? CreatedDateTo
) : IQuery<GetInventoriesQueryResult>;

public record GetInventoriesQueryResult(PaginatedResult<InventoryDto> Inventories);
