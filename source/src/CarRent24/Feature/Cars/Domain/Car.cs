using CarRent24.Common;

namespace CarRent24.Feature.Cars.Domain
{
    public class Car : Entity, IAggregateRoot
    {
        private Car() { }
        private Car(LicensePlate licensePlate, CarClass carClass, string brand, string type)
        {
            this.LicensePlate = licensePlate;
            this.Class = carClass;
            this.Brand = brand;
            this.Type = type;
        }
        public LicensePlate LicensePlate { get; private set; }
        public CarClass Class { get; private set; }
        public string Brand { get; private set; }
        public string Type { get; private set; }

        /// <summary>
        /// Returns a new Car-Object
        /// </summary>
        /// <param name="licensePlate">The car's license plate.</param>
        /// <param name="carClass">The class of the car</param>
        /// <param name="brand">The brand of the car</param>
        /// <param name="type">The type of the car</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the arguments are null or empty.</exception>
        /// <exception cref="DomainException">Thrown when a domain specific rule is violated.</exception>
        /// <returns>An object representing a car.</returns>
        public static Car Create(LicensePlate licensePlate, CarClass carClass, string brand, string type)
        {
            ArgumentNullException.ThrowIfNull(licensePlate);
            ArgumentNullException.ThrowIfNull(carClass);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(brand);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(type);

            return new Car(licensePlate, carClass, brand, type);
        }
    }
}