using IMS.Core.ValueObjects;
using IMS.UseCases.Data;
using IMS.UseCases.Exceptions;

namespace IMS.UseCases.Inventory.Commands.UpdateInventory;

public class UpdateInventoryCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateInventoryCommand, UpdateInventoryResult>
{
    public async Task<UpdateInventoryResult> Handle(
        UpdateInventoryCommand command,
        CancellationToken cancellationToken
    )
    {
        var currentInventory = await dbContext.Inventories.FindAsync(
            [InventoryId.Of(command.Inventory.InventoryId)],
            cancellationToken: cancellationToken
        );

        if (currentInventory == null)
        {
            throw new InventoryNotFoundException(command.Inventory.InventoryId);
        }

        currentInventory.Update(
            command.Inventory.InventoryName,
            command.Inventory.Quantity,
            command.Inventory.QuantityType,
            command.Inventory.Price
        );

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateInventoryResult(command.Inventory.InventoryId);
    }
}
