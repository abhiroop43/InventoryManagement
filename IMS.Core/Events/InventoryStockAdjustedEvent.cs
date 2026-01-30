namespace IMS.Core.Events;

public record InventoryStockAdjustedEvent(Guid InventoryId, decimal QuantityChanged, decimal NewQuantity)
    : DomainEvent;