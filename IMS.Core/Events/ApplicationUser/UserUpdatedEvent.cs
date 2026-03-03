namespace IMS.Core.Events.ApplicationUser;

public record UserUpdatedEvent(Models.ApplicationUser ApplicationUser) : DomainEvent;
