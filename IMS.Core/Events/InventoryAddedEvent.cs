namespace IMS.Core.Events;

public record InventoryAddedEvent(Inventory Inventory) : IDomainEvent;