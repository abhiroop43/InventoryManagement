using IMS.Core.ValueObjects;
using IMS.UseCases.Data;
using IMS.UseCases.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IMS.UseCases.Inventory.Commands.DeleteInventory;

public class DeleteInventoryCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteInventoryCommand, DeleteInventoryResult>
{
    public async Task<DeleteInventoryResult> Handle(
        DeleteInventoryCommand command,
        CancellationToken cancellationToken
    )
    {
        var inventory = await dbContext
            .Inventories.AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Id == InventoryId.Of(command.InventoryId),
                cancellationToken
            );

        if (inventory == null)
            throw new InventoryNotFoundException(command.InventoryId);

        dbContext.Inventories.Remove(inventory);
        var count = await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteInventoryResult(count > 0);
    }
}
