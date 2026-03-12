namespace IMS.UseCases.ApplicationUser.Commands.DeactivateApplicationUser;

public record DeactivateApplicationUserCommand(Guid UserId)
    : ICommand<DeactivateApplicationUserResult>;

public record DeactivateApplicationUserResult(bool IsSuccess);

public class DeactivateApplicationUserCommandValidator
    : AbstractValidator<DeactivateApplicationUserCommand>
{
    public DeactivateApplicationUserCommandValidator()
    {
        RuleFor(x => x.UserId).NotNull().WithMessage("User Id must be provided");
    }
}
