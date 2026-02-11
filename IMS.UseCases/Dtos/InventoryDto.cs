namespace IMS.UseCases.Dtos;

public class InventoryDto
{
    public InventoryDto() { }

    public Guid InventoryId { get; set; }
    public string InventoryName { get; set; }
    public decimal Quantity { get; set; }
    public QuantityType QuantityType { get; set; }
    public decimal Price { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
}
