using IMS.Core.ValueObjects;
using IMS.UseCases.Data;

namespace IMS.UseCases.ApplicationUser.Commands.AddApplicationUser;

public class AddApplicationUserCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<AddApplicationUserCommand, AddApplicationUserResult>
{
    public async Task<AddApplicationUserResult> Handle(
        AddApplicationUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var applicationUser = MapUserDtoToDomain(command);
        await dbContext.ApplicationUsers.AddAsync(applicationUser, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new AddApplicationUserResult(applicationUser.Id.Value);
    }

    private static Core.Models.ApplicationUser MapUserDtoToDomain(AddApplicationUserCommand command)
    {
        var userId = Guid.NewGuid();

        var applicationUser = Core.Models.ApplicationUser.Create(
            ApplicationUserId.Of(userId),
            command.UserDetails.Email,
            command.UserDetails.Uid,
            command.UserDetails.FullName
        );
        return applicationUser;
    }
}
