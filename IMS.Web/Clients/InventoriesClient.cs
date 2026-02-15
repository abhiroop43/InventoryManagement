using IMS.Core.Enums;
using IMS.Core.Pagination;
using IMS.UseCases.Dtos;
using IMS.UseCases.Inventory.Commands.CreateInventory;
using IMS.UseCases.Inventory.Commands.DeleteInventory;
using IMS.UseCases.Inventory.Commands.UpdateInventory;
using IMS.UseCases.Inventory.Queries.GetInventories;
using IMS.UseCases.Inventory.Queries.GetInventoryDetails;
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

    public async Task<Guid> AddNewInventory(InventoryDto inventory)
    {
        var command = new CreateInventoryCommand(inventory);
        var result = await sender.Send(command);
        return result.Id;
    }

    public async Task<Guid> UpdateExistingInventory(InventoryDto inventory)
    {
        var command = new UpdateInventoryCommand(inventory);
        var result = await sender.Send(command);
        return result.Id;
    }

    public async Task<bool> DeleteInventoryById(Guid inventoryId)
    {
        var command = new DeleteInventoryCommand(inventoryId);
        var result = await sender.Send(command);
        return result.Success;
    }

    public async Task<InventoryDto> GetInventoryById(Guid inventoryId)
    {
        var query = new GetInventoryDetailsQuery(inventoryId);
        var result = await sender.Send(query);
        return result.Inventory;
    }

    public static string[] GetQuantityTypes()
    {
        return Enum.GetNames<QuantityType>();
    }
}
