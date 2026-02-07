namespace IMS.UseCases.Inventory.Commands.UpdateInventory;

public class UpdateInventoryCommandHandler
    : ICommandHandler<UpdateInventoryCommand, UpdateInventoryResult>
{
    public async Task<UpdateInventoryResult> Handle(
        UpdateInventoryCommand request,
        CancellationToken cancellationToken
    )
    {
        return new UpdateInventoryResult(Guid.NewGuid());
    }
}
