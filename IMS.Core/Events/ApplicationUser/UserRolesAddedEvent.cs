using IMS.Core.Models;

namespace IMS.Core.Events.ApplicationUser;

public record UserRolesAddedEvent(ApplicationUserId UserId, List<string> AddedRoles) : DomainEvent;
