namespace IMS.Core.ValueObjects;

public record InventoryName
{
    private const int MinLength = 5;

    private InventoryName(string value)
    {
        Value = value;
    }

    public string Value { get; } = null!;

    public static InventoryName Of(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new DomainException("Inventory name cannot be null or whitespace");

        if (value.Length < MinLength)
            throw new DomainException($"Inventory name must be at least {MinLength} characters long");

        return new InventoryName(value);
    }
};