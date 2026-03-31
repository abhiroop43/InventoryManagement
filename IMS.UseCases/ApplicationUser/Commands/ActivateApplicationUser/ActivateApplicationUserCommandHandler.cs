using IMS.Core.ValueObjects;
using IMS.UseCases.Data;
using IMS.UseCases.Exceptions;

namespace IMS.UseCases.ApplicationUser.Commands.ActivateApplicationUser;

public class ActivateApplicationUserCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<ActivateApplicationUserCommand, ActivateApplicationUserResult>
{
    public async Task<ActivateApplicationUserResult> Handle(
        ActivateApplicationUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var currentUser = await dbContext.ApplicationUsers.FindAsync(
            [ApplicationUserId.Of(command.UserId)],
            cancellationToken
        );

        if (currentUser == null)
            throw new ApplicationUserNotFoundException(command.UserId);

        currentUser.ActivateUser();
        var updateCount = await dbContext.SaveChangesAsync(cancellationToken);

        return new ActivateApplicationUserResult(updateCount > 0);
    }
}
