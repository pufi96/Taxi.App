using MediatR;

namespace Taxi.Aplication.Features.Cars.Queries.ListCarsShift;

public class ListCarsShiftQuery : IRequest<List<CarsVm>>
{
}