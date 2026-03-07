namespace IMS.Core.ValueObjects;

public record UserRoleMappingId
{
    public Guid Value { get; }

    private UserRoleMappingId(Guid value)
    {
        Value = value;
    }

    public static UserRoleMappingId Of(Guid value)
    {
        return value == Guid.Empty
            ? throw new DomainException("User Role Mapping cannot be empty")
            : new UserRoleMappingId(value);
    }
}
