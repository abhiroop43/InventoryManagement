using IMS.UseCases.Data;

namespace IMS.UseCases.Inventory.Commands.CreateInventory;

public class CreateInventoryCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateInventoryCommand, CreateInventoryResult>
{
    public async Task<CreateInventoryResult> Handle(
        CreateInventoryCommand request,
        CancellationToken cancellationToken
    )
    {
        var inventory = request.Inventory.Adapt<Core.Models.Inventory>();
        dbContext.Inventories.Add(inventory);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateInventoryResult(inventory.Id.Value);
    }
}
