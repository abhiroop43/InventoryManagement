namespace IMS.UseCases.ApplicationUser.Commands.AddRolesToUser;

public record AddRolesToUserCommand(Guid UserId, List<Guid> RoleIds)
    : ICommand<AddRolesToUserResult>;

public record AddRolesToUserResult(bool IsSuccess);

public class AddRolesToUserValidator : AbstractValidator<AddRolesToUserCommand>
{
    public AddRolesToUserValidator()
    {
        RuleFor(u => u.UserId).NotEmpty().WithMessage("UserId is required");
        RuleFor(u => u.RoleIds).NotEmpty().WithMessage("RoleIds are required");
        RuleFor(u => u.RoleIds.Count)
            .GreaterThan(0)
            .WithMessage("At least one Role Id must be specified");
    }
}
