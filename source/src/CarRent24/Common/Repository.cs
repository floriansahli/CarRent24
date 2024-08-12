namespace CarRent24.Common
{
    // only allow aggragates to avoid incosinstant data
    // example -> SalesLineItem gets edited without editing the sale, which could render the sales invalid.
    public interface IRepository<TAggregate> where TAggregate : Entity, IAggregateRoot
    {
        TAggregate FindById(Guid id);
        void Add(TAggregate entity);
        void Remove(TAggregate entity);
    }
}