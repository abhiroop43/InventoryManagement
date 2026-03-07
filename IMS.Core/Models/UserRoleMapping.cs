namespace IMS.Core.Models;

public class UserRoleMapping : Entity<UserRoleMappingId>
{
    public ApplicationUserRoleId RoleId { get; set; } = null!;
    public ApplicationUserId UserId { get; set; } = null!;

    public static UserRoleMapping Create(
        UserRoleMappingId id,
        ApplicationUserRoleId roleId,
        ApplicationUserId userId
    )
    {
        var roleMapping = new UserRoleMapping
        {
            Id = id,
            UserId = userId,
            RoleId = roleId,
        };

        return roleMapping;
    }
}
