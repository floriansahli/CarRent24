using CarRent24.Common;

namespace CarRent24.Feature.Cars.Domain
{
    public interface ICarRepository : IRepository<Car>
    {
        IReadOnlyList<Car> GetCars();

    }
}