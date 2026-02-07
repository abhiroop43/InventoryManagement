namespace IMS.UseCases.Inventory.Commands.UpdateInventory;

public record UpdateInventoryCommand : ICommand<UpdateInventoryResult>;

public record UpdateInventoryResult(Guid Id);
