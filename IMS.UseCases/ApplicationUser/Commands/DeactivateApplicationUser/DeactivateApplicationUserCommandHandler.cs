using IMS.Core.ValueObjects;
using IMS.UseCases.Data;
using IMS.UseCases.Exceptions;

namespace IMS.UseCases.ApplicationUser.Commands.DeactivateApplicationUser;

public class DeactivateApplicationUserCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeactivateApplicationUserCommand, DeactivateApplicationUserResult>
{
    public async Task<DeactivateApplicationUserResult> Handle(
        DeactivateApplicationUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var currentUser = await dbContext.ApplicationUsers.FindAsync(
            [ApplicationUserId.Of(command.UserId)],
            cancellationToken
        );

        if (currentUser == null)
            throw new ApplicationUserNotFoundException(command.UserId);

        currentUser.DeactivateUser();

        var updateCount = await dbContext.SaveChangesAsync(cancellationToken);

        return new DeactivateApplicationUserResult(updateCount > 0);
    }
}
