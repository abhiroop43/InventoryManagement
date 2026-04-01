using IMS.Core.Exceptions;
using IMS.Core.ValueObjects;
using IMS.UseCases.Data;
using IMS.UseCases.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IMS.UseCases.ApplicationUser.Commands.RemoveRolesFromUser;

public class RemoveRolesFromUserCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<RemoveRolesFromUserCommand, RemoveRolesFromUserResult>
{
    public async Task<RemoveRolesFromUserResult> Handle(
        RemoveRolesFromUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var currentUser = await dbContext.ApplicationUsers.FindAsync(
            [ApplicationUserId.Of(command.UserId)],
            cancellationToken
        );

        if (currentUser == null)
        {
            throw new ApplicationUserNotFoundException(command.UserId);
        }

        foreach (var roleId in command.RoleIds)
        {
            var applicationRole = await dbContext.ApplicationUserRoles.FindAsync(
                [ApplicationUserRoleId.Of(roleId)],
                cancellationToken
            );

            if (applicationRole == null)
            {
                throw new ApplicationUserRoleNotFoundException(roleId);
            }

            var existingRole = await dbContext.UserRoleMappings.FirstOrDefaultAsync(
                x =>
                    x.UserId == ApplicationUserId.Of(command.UserId)
                    && x.RoleId == ApplicationUserRoleId.Of(roleId),
                cancellationToken
            );

            if (existingRole == null)
            {
                throw new BadRequestException($"The role {roleId} does not exist for this user.");
            }

            dbContext.UserRoleMappings.Remove(existingRole);
        }

        var updateCount = await dbContext.SaveChangesAsync(cancellationToken);

        return new RemoveRolesFromUserResult(updateCount > 0);
    }
}
