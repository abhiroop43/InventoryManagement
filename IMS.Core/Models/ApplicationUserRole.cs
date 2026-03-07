namespace IMS.Core.Models;

public class ApplicationUserRole : Aggregate<ApplicationUserRoleId>
{
    public string RoleCode { get; set; } = null!;
    public string RoleName { get; set; } = null!;

    private readonly List<UserRoleMapping> _users = [];
    public IReadOnlyList<UserRoleMapping> UsersInRole => _users.AsReadOnly();

    public static ApplicationUserRole Create(
        ApplicationUserRoleId roleId,
        string roleCode,
        string roleName
    )
    {
        if (string.IsNullOrEmpty(roleCode))
        {
            throw new DomainException("Role Code cannot be empty");
        }

        if (string.IsNullOrEmpty(roleName))
        {
            throw new DomainException("Role Name cannot be empty");
        }

        var role = new ApplicationUserRole
        {
            Id = roleId,
            RoleCode = roleCode,
            RoleName = roleName,
        };

        return role;
    }
}
