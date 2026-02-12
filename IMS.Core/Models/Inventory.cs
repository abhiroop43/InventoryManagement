namespace IMS.Core.Models;

public class Inventory : Aggregate<InventoryId>
{
    public InventoryName ItemName { get; private set; } = null!;
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
        if (price <= 0)
            throw new DomainException("Price cannot be zero or negative");

        if (quantity <= 0)
            throw new DomainException("Quantity cannot be zero or negative");

        var inventory = new Inventory
        {
            Id = inventoryId,
            ItemName = inventoryName,
            Quantity = quantity,
            QuantityType = quantityType,
            Price = price,
        };

        inventory.AddDomainEvent(
            new InventoryAddedEvent(
                inventory.Id.Value,
                inventory.ItemName.Value,
                inventory.Quantity,
                inventory.QuantityType,
                inventory.Price
            )
        );

        return inventory;
    }

    public void Update(
        string inventoryName,
        decimal quantity,
        QuantityType quantityType,
        decimal price
    )
    {
        if (price <= 0)
            throw new DomainException("Price cannot be zero or negative");

        if (quantity <= 0)
            throw new DomainException("Quantity cannot be zero or negative");

        if (string.IsNullOrWhiteSpace(inventoryName))
            throw new DomainException("Inventory name cannot be null or whitespace");

        Quantity = quantity;
        QuantityType = quantityType;
        Price = price;
        ItemName = InventoryName.Of(inventoryName);

        AddDomainEvent(
            new InventoryUpdatedEvent(Id.Value, ItemName.Value, Quantity, QuantityType, Price)
        );
    }

    public void AdjustStock(decimal quantityChanged)
    {
        var newQuantity = Quantity + quantityChanged;

        if (newQuantity < 0)
            throw new DomainException("Insufficient stock");

        Quantity = newQuantity;

        AddDomainEvent(new InventoryStockAdjustedEvent(Id.Value, quantityChanged, newQuantity));

        if (Quantity == 0)
            AddDomainEvent(new InventoryStockDepletedEvent(Id.Value));
    }
}
