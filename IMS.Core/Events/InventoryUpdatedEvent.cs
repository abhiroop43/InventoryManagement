namespace IMS.Core.Events;

public record InventoryUpdatedEvent(Inventory Inventory) : IDomainEvent;