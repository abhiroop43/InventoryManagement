namespace IMS.UseCases.Inventory.Commands.CreateInventory;

public record CreateInventoryCommand(InventoryDto Inventory) : ICommand<CreateInventoryResult>;

public record CreateInventoryResult(Guid Id);

public class CreateInventoryCommandValidator : AbstractValidator<CreateInventoryCommand>
{
    public CreateInventoryCommandValidator()
    {
        RuleFor(x => x.Inventory).NotNull();
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
