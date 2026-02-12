namespace IMS.UseCases.Dtos;

public class InventoryDto
{
    public Guid InventoryId { get; set; }
    public string InventoryName { get; set; } = null!;
    public decimal Quantity { get; set; }
    public QuantityType QuantityType { get; set; }
    public decimal Price { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string UpdatedBy { get; set; } = null!;
    public DateTime UpdatedDate { get; set; }
}
