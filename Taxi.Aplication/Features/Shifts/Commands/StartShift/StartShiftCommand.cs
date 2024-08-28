using MediatR;

namespace Taxi.Aplication.Features.Shifts.Commands.StartShift;
public class StartShiftCommand : IRequest<StartShiftCommandResponse>
{
    public int MileageStart { get; set; }
    public int CarId { get; set; }
    public int UserId { get; set; }
}