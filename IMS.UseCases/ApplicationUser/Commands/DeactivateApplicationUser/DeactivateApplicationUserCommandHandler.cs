namespace IMS.UseCases.ApplicationUser.Commands.DeactivateApplicationUser;

public class DeactivateApplicationUserCommandHandler
    : ICommandHandler<DeactivateApplicationUserCommand, DeactivateApplicationUserResult>
{
    public Task<DeactivateApplicationUserResult> Handle(
        DeactivateApplicationUserCommand request,
        CancellationToken cancellationToken
    )
    {
        throw new NotImplementedException();
    }
}
