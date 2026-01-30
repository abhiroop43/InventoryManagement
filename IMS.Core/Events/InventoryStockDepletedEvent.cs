namespace IMS.Core.Events;

public record InventoryStockDepletedEvent(Guid InventoryId) : DomainEvent;