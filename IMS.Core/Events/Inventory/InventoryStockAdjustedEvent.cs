namespace IMS.Core.Events.Inventory;

public record InventoryStockAdjustedEvent(
    Guid InventoryId,
    decimal QuantityChanged,
    decimal NewQuantity
) : DomainEvent;
