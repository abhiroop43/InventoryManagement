namespace IMS.UseCases.Dtos;

public class UserDto
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Uid { get; set; }
    public IReadOnlyList<RoleDto> UserRoles { get; set; }

    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string UpdatedBy { get; set; } = null!;
    public DateTime UpdatedDate { get; set; }
}
