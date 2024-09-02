using CarRent24.Common;
using CarRent24.Feature.Cars.Domain;
using CarRent24.Feature.Customers.Domain;
using System.Diagnostics.CodeAnalysis;

namespace CarRent24.Feature.Reservations.Domain
{
    public class Reservation : Entity
    {
        [ExcludeFromCodeCoverage(Justification = "EF Core")]
        public Reservation() { }
        public Reservation(Customer customer, CarClass carClass, DateOnly startDate, DateOnly endDate)
        {
            Customer = customer;
            CarClass = carClass;
            StartDate = startDate;
            EndDate = endDate;
            TotalAmount = carClass.Amount * DurationInDays;
        }

        public Customer Customer { get; private set; }
        public CarClass CarClass { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public int DurationInDays => EndDate.DayNumber - StartDate.DayNumber;
        
        public decimal TotalAmount { get; private set; }

        public static Reservation Create(Customer customer, CarClass carClass, DateOnly startDate, DateOnly endDate)
        {
            return new Reservation(customer, carClass, startDate, endDate);
        }
    }
}
