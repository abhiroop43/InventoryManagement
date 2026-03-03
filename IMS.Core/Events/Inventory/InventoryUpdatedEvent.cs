namespace IMS.Core.Events.Inventory;

public record InventoryUpdatedEvent(
    Guid InventoryId,
    string InventoryName,
    decimal Quantity,
    QuantityType QuantityType,
    decimal Price
) : DomainEvent;
