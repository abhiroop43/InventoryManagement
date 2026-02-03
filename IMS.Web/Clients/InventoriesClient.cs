using IMS.Core.Pagination;
using IMS.UseCases.Dtos;
using IMS.UseCases.Inventory.Queries.GetInventories;
using MediatR;

namespace IMS.Web.Clients;

public class InventoriesClient(ISender sender)
{
    public async Task<PaginatedResult<InventoryDto>> GetInventories()
    {
        var query = new GetInventoriesQuery(new PaginationRequest());
        var result = await sender.Send(query);
        return result.Inventories;
    }
}
