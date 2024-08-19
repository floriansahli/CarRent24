using CarRent24.Feature.Cars.Domain;
using FastEndpoints;

namespace CarRent24.Feature.Cars.API
{
    public class GetCarsEndpoint : EndpointWithoutRequest<IEnumerable<CarResponse>>
    {
        private readonly ICarRepository _repository;
        public GetCarsEndpoint(ICarRepository repository)
        {
            this._repository = repository;
        }
        public override void Configure()
        {
            Get("/cars");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var cars = this._repository.GetCars();

            var reponse = cars.Select(Car => new CarResponse
            {
                Id = Car.Id,
                Name = Car.Name,
            });
            await SendOkAsync(reponse, ct);
        }
    }
}
