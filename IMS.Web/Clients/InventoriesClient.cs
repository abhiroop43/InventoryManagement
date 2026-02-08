using IMS.Core.Pagination;
using IMS.UseCases.Dtos;
using IMS.UseCases.Inventory.Commands.DeleteInventory;
using IMS.UseCases.Inventory.Queries.GetInventories;
using MediatR;

namespace IMS.Web.Clients;

public class InventoriesClient(ISender sender)
{
    public async Task<PaginatedResult<InventoryDto>> GetInventories(int pageIndex, int pageSize)
    {
        var query = new GetInventoriesQuery(new PaginationRequest(pageIndex, pageSize));
        var result = await sender.Send(query);
        return result.Inventories;
    }

    public async Task<bool> DeleteInventoryById(Guid inventoryId)
    {
        var command = new DeleteInventoryCommand(inventoryId);
        var result = await sender.Send(command);
        return result.Success;
    }
}
