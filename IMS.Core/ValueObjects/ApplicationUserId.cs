namespace IMS.Core.ValueObjects;

public record ApplicationUserId
{
    public Guid Value { get; }

    private ApplicationUserId(Guid value)
    {
        Value = value;
    }

    public static ApplicationUserId Of(Guid value)
    {
        return value == Guid.Empty 
            ? throw new DomainException("Application User ID cannot be empty") 
            : new ApplicationUserId(value);
    }
};