namespace IMS.UseCases.Inventory.Commands.DeleteInventory;

public record DeleteInventoryCommand(Guid InventoryId) : ICommand<DeleteInventoryResult>;

public record DeleteInventoryResult(bool Success);

public class DeleteInventoryCommandValidator : AbstractValidator<DeleteInventoryCommand>
{
    public DeleteInventoryCommandValidator()
    {
        RuleFor(x => x.InventoryId).NotEmpty().WithMessage("Inventory Id is required");
    }
}
