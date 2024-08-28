using AutoMapper;
using Taxi.Aplication.Features.Shifts.Commands.StartShift;
using Taxi.Domain.Entities;
using ShiftEntity = Taxi.Domain.Entities.Shift;

namespace Taxi.Aplication.MappingProfiles;

public class ShiftProfile : Profile
{
    public ShiftProfile()
    {
        CreateMap<ShiftEntity, StartShiftVm>();
    }
}