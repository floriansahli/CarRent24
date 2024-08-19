using CarRent24.Feature.Cars.Domain;
using FastEndpoints;

namespace CarRent24.Feature.Cars.API
{
    public class GetCarByIdEndpoint : EndpointWithoutRequest<CarResponse>
    {
        private readonly ICarRepository _repository;

        public GetCarByIdEndpoint(ICarRepository repository)
        {
            this._repository = repository;
        }
        public override void Configure()
        {
            Get("/cars/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var carId = Route<Guid>("id");
            var car = _repository.FindById(carId);
            await SendAsync(new CarResponse
            {
                Id = car.Id,
                Name=car.Name
            }, StatusCodes.Status200OK, ct);
        }
    }
}
