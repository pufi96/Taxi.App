using Taxi.Aplication.Responses;

namespace Taxi.Aplication.Features.Shifts.Commands.StartShift;

public class StartShiftCommandResponse : BaseResponse
{
    public StartShiftCommandResponse() : base()
    {
    }
    public StartShiftVm Shift { get; set; } = default!;
}
