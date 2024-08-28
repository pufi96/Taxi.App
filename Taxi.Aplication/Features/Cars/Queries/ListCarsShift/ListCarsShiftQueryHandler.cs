using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Aplication.Contracts.Persistence;
using Taxi.Aplication.Features.Shifts.Queries.GetShiftsList;

namespace Taxi.Aplication.Features.Cars.Queries.ListCarsShift;

public class ListCarsShiftQueryHandler : IRequestHandler<ListCarsShiftQuery, List<CarsVm>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public ListCarsShiftQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<List<CarsVm>> Handle(ListCarsShiftQuery request, CancellationToken cancellationToken)
    {
        var carsShift = await _carRepository.ListCarsShift();
        return _mapper.Map<List<CarsVm>>(carsShift);
    }
}