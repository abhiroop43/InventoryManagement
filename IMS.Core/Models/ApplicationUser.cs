using IMS.Core.Events.ApplicationUser;

namespace IMS.Core.Models;

public class ApplicationUser : Aggregate<ApplicationUserId>
{
    public string FullName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Uid { get; private set; } = null!;
    public UserPreferences UserPreferences { get; private set; } = null!;
    public bool IsActive { get; set; } = true;

    private readonly List<UserRoleMapping> _roles = [];
    public IReadOnlyList<UserRoleMapping> UserRoles => _roles.AsReadOnly();

    public static ApplicationUser Create(
        ApplicationUserId userId,
        string email,
        string uid,
        string fullName
    )
    {
        var appUser = new ApplicationUser
        {
            Id = userId,
            Email = email,
            Uid = uid,
            UserPreferences = new UserPreferences(false),
            FullName = fullName,
        };

        appUser.AddDomainEvent(new UserCreatedEvent(appUser));

        return appUser;
    }

    public void Update(string fullName, string email)
    {
        Email = email;
        FullName = fullName;

        AddDomainEvent(new UserUpdatedEvent(this));
    }

    public void UpdatePreferences(UserPreferences preferences)
    {
        UserPreferences = preferences;

        AddDomainEvent(new UserPreferencesUpdatedEvent(this));
    }

    public void DeactivateUser()
    {
        IsActive = false;
        AddDomainEvent(new UserDeactivatedEvent(Id));
    }

    public void ActivateUser()
    {
        IsActive = true;
        AddDomainEvent(new UserActivatedEvent(Id));
    }

    public void AddUserToRoles(List<UserRoleMapping> mappedRoles, List<string> roleCodes)
    {
        _roles.AddRange(mappedRoles);
        AddDomainEvent(new UserRolesAddedEvent(Id, roleCodes));
    }

    public void RemoveUserFromRoles(
        List<UserRoleMapping> mappedRolesToRemove,
        List<string> roleCodes
    )
    {
        foreach (var role in mappedRolesToRemove)
        {
            var roleExists = _roles.Contains(role);

            if (roleExists)
            {
                _roles.Remove(role);
            }
            else
            {
                throw new DomainException("Role does not exist for this user");
            }
        }
        AddDomainEvent(new UserRolesRemovedEvent(Id, roleCodes));
    }
}
