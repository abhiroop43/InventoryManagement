namespace IMS.Core.Events.Inventory;

public record InventoryStockDepletedEvent(Guid InventoryId) : DomainEvent;
