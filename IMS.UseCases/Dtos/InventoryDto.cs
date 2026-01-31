namespace IMS.UseCases.Dtos;

public record InventoryDto(
    Guid InventoryId,
    string InventoryName,
    decimal Quantity,
    QuantityType QuantityType,
    decimal Price,
    string CreatedBy,
    DateTime CreatedDate,
    string UpdatedBy,
    DateTime UpdatedDate
);
