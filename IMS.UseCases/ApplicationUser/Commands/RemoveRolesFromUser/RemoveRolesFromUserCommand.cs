namespace IMS.UseCases.ApplicationUser.Commands.RemoveRolesFromUser;

public record RemoveRolesFromUserCommand(Guid UserId, List<Guid> RoleIds)
    : ICommand<RemoveRolesFromUserResult>;

public record RemoveRolesFromUserResult(bool IsSuccess);

public class RemoveRolesFromUserValidator : AbstractValidator<RemoveRolesFromUserCommand>
{
    public RemoveRolesFromUserValidator()
    {
        RuleFor(cmd => cmd.UserId).NotEmpty().WithMessage("UserId cannot be empty");
        RuleFor(cmd => cmd.RoleIds).NotEmpty().WithMessage("RoleIds cannot be empty");
        RuleFor(cmd => cmd.RoleIds.Count)
            .GreaterThan(0)
            .WithMessage("At least one Role Id must be specified");
    }
}
