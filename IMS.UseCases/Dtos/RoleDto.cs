namespace IMS.UseCases.Dtos;

public class RoleDto
{
    public Guid RoleId { get; set; }
    public string RoleCode { get; set; }
    public string RoleName { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string UpdatedBy { get; set; } = null!;
    public DateTime UpdatedDate { get; set; }
}
