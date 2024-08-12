using CarRent24.Common;

namespace CarRent24.Feature.Cars.Domain
{
    public class Car : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

    }
}