namespace IMS.Core.Models;

public class Inventory : Aggregate<InventoryId>
{
    public InventoryName InventoryName { get; private set; } = null!;
    public decimal Quantity { get; private set; }
    public QuantityType QuantityType { get; private set; }
    public decimal Price { get; private set; }

    public static Inventory Add(
        InventoryId inventoryId,
        InventoryName inventoryName,
        decimal quantity,
        QuantityType quantityType,
        decimal price
    )
    {
        if (price <= 0) throw new DomainException("Price cannot be zero or negative");

        if (quantity <= 0) throw new DomainException("Quantity cannot be zero or negative");

        var inventory = new Inventory
        {
            Id = inventoryId,
            InventoryName = inventoryName,
            Quantity = quantity,
            QuantityType = quantityType,
            Price = price
        };

        inventory.AddDomainEvent(new InventoryAddedEvent(inventory));

        return inventory;
    }

    public void Update(
        decimal quantity,
        QuantityType quantityType,
        decimal price
    )
    {
        Quantity = quantity;
        QuantityType = quantityType;
        Price = price;

        AddDomainEvent(new InventoryUpdatedEvent(this));
    }

    public void AdjustStock(decimal quantityChanged)
    {
        var newQuantity = Quantity + quantityChanged;

        if (newQuantity < 0) throw new DomainException("Insufficient stock");

        Quantity = newQuantity;

        AddDomainEvent(new InventoryStockAdjustedEvent(Id, quantityChanged, newQuantity));

        if (Quantity == 0) AddDomainEvent(new InventoryStockDepletedEvent(Id));
    }
}