using IMS.Core.ValueObjects;
using IMS.UseCases.Data;

namespace IMS.UseCases.Inventory.Commands.CreateInventory;

public class CreateInventoryCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateInventoryCommand, CreateInventoryResult>
{
    public async Task<CreateInventoryResult> Handle(
        CreateInventoryCommand command,
        CancellationToken cancellationToken
    )
    {
        var inventory = AddInventoryToDomain(command);
        await dbContext.Inventories.AddAsync(inventory, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateInventoryResult(inventory.Id.Value);
    }

    private static Core.Models.Inventory AddInventoryToDomain(CreateInventoryCommand command)
    {
        var inventoryId = Guid.NewGuid();

        var inventory = Core.Models.Inventory.Add(
            InventoryId.Of(inventoryId),
            InventoryName.Of(command.Inventory.InventoryName),
            command.Inventory.Quantity,
            command.Inventory.QuantityType,
            command.Inventory.Price
        );
        return inventory;
    }
}
