using IMS.Core.ValueObjects;
using IMS.UseCases.Data;
using IMS.UseCases.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IMS.UseCases.Inventory.Commands.UpdateInventory;

public class UpdateInventoryCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateInventoryCommand, UpdateInventoryResult>
{
    public async Task<UpdateInventoryResult> Handle(
        UpdateInventoryCommand command,
        CancellationToken cancellationToken
    )
    {
        var currentInventory = await dbContext
            .Inventories.AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Id == InventoryId.Of(command.Inventory.InventoryId),
                cancellationToken
            );

        if (currentInventory == null)
        {
            throw new InventoryNotFoundException(command.Inventory.InventoryId);
        }

        command.Inventory.Adapt(currentInventory);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateInventoryResult(command.Inventory.InventoryId);
    }
}
