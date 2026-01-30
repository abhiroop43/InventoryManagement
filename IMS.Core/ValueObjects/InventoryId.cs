namespace IMS.Core.ValueObjects;

public record InventoryId
{
    private InventoryId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static InventoryId Of(Guid value)
    {
        if (value == Guid.Empty) throw new DomainException("Inventory ID cannot be empty");
        return new InventoryId(value);
    }
}