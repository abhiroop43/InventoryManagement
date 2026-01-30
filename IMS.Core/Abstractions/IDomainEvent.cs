using MediatR;

namespace IMS.Core.Abstractions;

public interface IDomainEvent : INotification
{
    Guid EventId { get; }
    DateTime OccurredOn { get; }
    string? EventType { get; }
}