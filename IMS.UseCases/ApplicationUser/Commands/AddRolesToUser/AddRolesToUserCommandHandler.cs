using IMS.Core.Exceptions;
using IMS.Core.Models;
using IMS.Core.ValueObjects;
using IMS.UseCases.Data;
using IMS.UseCases.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IMS.UseCases.ApplicationUser.Commands.AddRolesToUser;

public class AddRolesToUserCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<AddRolesToUserCommand, AddRolesToUserResult>
{
    public async Task<AddRolesToUserResult> Handle(
        AddRolesToUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var currentUser = await dbContext.ApplicationUsers.FindAsync(
            [ApplicationUserId.Of(command.UserId)],
            cancellationToken: cancellationToken
        );

        if (currentUser == null)
        {
            throw new ApplicationUserNotFoundException(command.UserId);
        }

        foreach (var roleId in command.RoleIds)
        {
            var roleToBeAdded = await dbContext.ApplicationUserRoles.FindAsync(
                [ApplicationUserRoleId.Of(roleId)],
                cancellationToken: cancellationToken
            );

            if (roleToBeAdded == null)
            {
                throw new ApplicationUserRoleNotFoundException(roleId);
            }

            var existingRole = await dbContext.UserRoleMappings.FirstOrDefaultAsync(
                x =>
                    x.UserId == ApplicationUserId.Of(command.UserId)
                    && x.RoleId == ApplicationUserRoleId.Of(roleId),
                cancellationToken
            );

            if (existingRole != null)
            {
                throw new BadRequestException(
                    $"The role {roleId} is already assigned to the user."
                );
            }

            var newUserRole = new UserRoleMapping
            {
                Id = UserRoleMappingId.Of(Guid.NewGuid()),
                RoleId = ApplicationUserRoleId.Of(roleId),
                UserId = ApplicationUserId.Of(command.UserId),
            };

            dbContext.UserRoleMappings.Add(newUserRole);
        }

        var updateCount = await dbContext.SaveChangesAsync(cancellationToken);

        return new AddRolesToUserResult(updateCount > 0);
    }
}
