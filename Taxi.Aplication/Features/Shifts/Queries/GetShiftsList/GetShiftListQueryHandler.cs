using AutoMapper;
using MediatR;
using Taxi.Aplication.Contracts.Persistence;
using Taxi.Domain.Entities;

namespace Taxi.Aplication.Features.Shifts.Queries.GetShiftsList;

public class GetShiftListQueryHandler : IRequestHandler<GetShiftsListQuery, List<ShiftListVm>>
{
    private readonly IShiftRepository _shiftRepository;
    private readonly IMapper _mapper;

    public GetShiftListQueryHandler(IShiftRepository shiftRepository, IMapper mapper)
    {
        _shiftRepository = shiftRepository;
        _mapper = mapper;
    }

    public async Task<List<ShiftListVm>> Handle(GetShiftsListQuery request, CancellationToken cancellationToken)
    {
        var shiftByUser = await _shiftRepository.GetShiftsUser(request.UserId);
        return _mapper.Map<List<ShiftListVm>>(shiftByUser);
    }
}