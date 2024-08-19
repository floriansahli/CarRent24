using CarRent24.Common;
using CarRent24.Feature.Cars.Domain;
using FastEndpoints;

namespace CarRent24.Feature.Cars.API
{
    public class CreateCarEndpoint : Endpoint<CarRequest, CarResponse>
    {
        private readonly ICarRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarEndpoint(IUnitOfWork unitOfWork, ICarRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }
        public override void Configure()
        {
            Post("/cars");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CarRequest req, CancellationToken ct)
        {
            var car = new Car
            {
                Name = req.Name,
            };

            _repository.Add(car);
            _unitOfWork.CommitChanges();

            // TODO fix location header
            // this will provide the reponse header with the location. 
            // correct REST API would do that
            await SendCreatedAtAsync<GetCarByIdEndpoint>(car.Id, new CarResponse
            {
                Id = car.Id,
                Name = car.Name

            });
        }
    }
}
