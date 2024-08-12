namespace CarRent24.Domain.Common
{
    public interface IAggregateRoot
    {
        public IReadOnlyList<IDomainEvent> DomainEvents { get; }
    }
}