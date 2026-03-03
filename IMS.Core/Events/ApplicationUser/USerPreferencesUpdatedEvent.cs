namespace IMS.Core.Events.ApplicationUser;

public record UserPreferencesUpdatedEvent(Models.ApplicationUser ApplicationUser) : DomainEvent;
