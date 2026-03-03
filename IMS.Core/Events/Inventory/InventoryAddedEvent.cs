namespace IMS.Core.Events.Inventory;

public record InventoryAddedEvent(
    Guid InventoryId,
    string InventoryName,
    decimal Quantity,
    QuantityType QuantityType,
    decimal Price
) : DomainEvent;
