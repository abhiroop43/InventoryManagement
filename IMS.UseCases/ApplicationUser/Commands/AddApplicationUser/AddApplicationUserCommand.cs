namespace IMS.UseCases.ApplicationUser.Commands.AddApplicationUser;

public record AddApplicationUserCommand(UserDto UserDetails) : ICommand<AddApplicationUserResult>;

public record AddApplicationUserResult(Guid UserId);

public class AddApplicationUserValidator : AbstractValidator<AddApplicationUserCommand>
{
    public AddApplicationUserValidator()
    {
        RuleFor(x => x.UserDetails).NotNull();
        RuleFor(x => x.UserDetails.Email)
            .EmailAddress()
            .WithMessage("Please provide a valid email");
        RuleFor(x => x.UserDetails.FullName)
            .NotEmpty()
            .WithMessage("Please provide the full name of the user");
        RuleFor(x => x.UserDetails.Uid).NotEmpty().WithMessage("Please provide a UID for the user");
    }
}
