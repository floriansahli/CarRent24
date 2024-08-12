namespace CarRent24.Common
{
    public interface IAggregateRoot
    {
        public IReadOnlyList<IDomainEvent> DomainEvents { get; }
    }
}