using CarRent24.Common;
using CarRent24.Feature.Cars.Domain;
using CarRent24.Persistence;

namespace CarRent24.Feature.Cars.Infrastructure
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentDbContext _context;

        public CarRepository(CarRentDbContext context)
        {
            this._context = context;
        }
        public void Add(Car entity)
        {
            this._context.Set<Car>().Add(entity);
        }

        public Car FindById(Guid id)
        {
            return this._context.Set<Car>().Find([id]);
        }

        public IReadOnlyList<Car> GetCars()
        {
            return this._context.Set<Car>().ToList();
        }

        public void Remove(Car entity)
        {
            this._context.Set<Car>().Remove(entity);
        }
    }
}