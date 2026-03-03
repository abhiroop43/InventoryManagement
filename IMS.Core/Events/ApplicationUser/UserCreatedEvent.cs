namespace IMS.Core.Events.ApplicationUser;

public record UserCreatedEvent(Models.ApplicationUser ApplicationUser) : DomainEvent;
