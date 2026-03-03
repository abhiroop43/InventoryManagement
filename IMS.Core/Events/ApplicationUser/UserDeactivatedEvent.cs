namespace IMS.Core.Events.ApplicationUser;

public record UserDeactivatedEvent(ApplicationUserId UserId) : DomainEvent;
