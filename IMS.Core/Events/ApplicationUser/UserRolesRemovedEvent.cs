using IMS.Core.Models;

namespace IMS.Core.Events.ApplicationUser;

public record UserRolesRemovedEvent(ApplicationUserId UserId, List<string> RemovedRoles)
    : DomainEvent;
