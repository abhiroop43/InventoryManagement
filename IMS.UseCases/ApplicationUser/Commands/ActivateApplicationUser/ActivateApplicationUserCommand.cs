namespace IMS.UseCases.ApplicationUser.Commands.ActivateApplicationUser;

public record ActivateApplicationUserCommand(Guid UserId) : ICommand<ActivateApplicationUserResult>;

public record ActivateApplicationUserResult(bool IsSuccess);

public class ActivateApplicationUserValidator : AbstractValidator<ActivateApplicationUserCommand>
{
    public ActivateApplicationUserValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId cannot be empty");
    }
}
