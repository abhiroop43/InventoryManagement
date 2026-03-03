namespace IMS.Core.Events.ApplicationUser;

public record UserActivatedEvent(ApplicationUserId UserId) : DomainEvent;
