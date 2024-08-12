using CarRent24.Domain.Common;

namespace CarRent24.Domain.Cars
{
    public class Car : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

    }
}