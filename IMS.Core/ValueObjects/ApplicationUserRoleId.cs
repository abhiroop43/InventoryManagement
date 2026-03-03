namespace IMS.Core.ValueObjects;

public record ApplicationUserRoleId
{
    private ApplicationUserRoleId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static ApplicationUserRoleId Of(Guid value)
    {
        return value == Guid.Empty
            ? throw new DomainException("Role Id cannot be empty")
            : new ApplicationUserRoleId(value);
    }
}
