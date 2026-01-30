namespace IMS.Core.Events;

public record InventoryStockAdjustedEvent(InventoryId InventoryId, decimal QuantityChanged, decimal NewQuantity)
    : IDomainEvent;