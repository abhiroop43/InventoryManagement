namespace IMS.UseCases.Inventory.Commands.UpdateInventory;

public record UpdateInventoryCommand(InventoryDto Inventory) : ICommand<UpdateInventoryResult>;

public record UpdateInventoryResult(Guid Id);

public class UpdateInventoryCommandValidator : AbstractValidator<UpdateInventoryCommand>
{
    public UpdateInventoryCommandValidator()
    {
        RuleFor(x => x.Inventory).NotNull().WithMessage("Inventory cannot be null");
        RuleFor(x => x.Inventory.InventoryId)
            .NotNull()
            .WithMessage("{PropertyName} cannot be null");
        RuleFor(x => x.Inventory.Price)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");
        RuleFor(x => x.Inventory.Quantity)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");
        RuleFor(x => x.Inventory.InventoryName)
            .MinimumLength(5)
            .WithMessage("{PropertyName} must be at least 5 characters long");
    }
}
