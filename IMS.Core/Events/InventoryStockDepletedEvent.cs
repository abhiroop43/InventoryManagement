namespace IMS.Core.Events;

public record InventoryStockDepletedEvent(InventoryId InventoryId) : IDomainEvent;