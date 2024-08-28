using MediatR;

namespace Taxi.Aplication.Features.Shifts.Queries.GetShiftsList;

public class GetShiftsListQuery : IRequest<List<ShiftListVm>>
{
    public int UserId { get; set; }
}