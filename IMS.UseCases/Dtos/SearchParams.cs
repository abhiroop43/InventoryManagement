namespace IMS.UseCases.Dtos;

public class SearchParams
{
    public string? InventoryName { get; set; }
    public DateTime? CreatedDateFrom { get; set; }
    public DateTime? CreatedDateTo { get; set; }
}
