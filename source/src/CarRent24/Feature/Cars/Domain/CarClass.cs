using CarRent24.Common;

namespace CarRent24.Feature.Cars.Domain
{
    /// <summary>
    /// Defines daily rate
    /// </summary>
    public abstract class CarClass : Entity
    {
        protected CarClass(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; }
    }
}
