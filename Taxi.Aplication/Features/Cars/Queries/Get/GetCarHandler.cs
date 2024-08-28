using AutoMapper;
using MediatR;
using Taxi.Aplication.Contracts.Persistence;
using Taxi.Domain.Entities;

namespace Taxi.Aplication.Features.Cars.Queries.Get;

public class GetCarHandler : IRequestHandler<GetCarQuery, CarVm>
{
    private readonly IAsyncRepository<Car> _carRepository;
    private readonly IMapper _mapper;

    public GetCarHandler(IAsyncRepository<Car> carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public Task<CarVm> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
    }
}