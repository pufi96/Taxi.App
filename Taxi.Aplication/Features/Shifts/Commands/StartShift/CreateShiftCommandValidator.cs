using FluentValidation;
using Taxi.Aplication.Contracts.Persistence;

namespace Taxi.Aplication.Features.Shifts.Commands.StartShift;
public class CreateShiftCommandValidator : AbstractValidator<StartShiftCommand>
{
    private readonly IShiftRepository _eventRepository;
    public CreateShiftCommandValidator(IShiftRepository eventRepository)
    {
        _eventRepository = eventRepository;

        RuleFor(x => x.CarId)
            .NotEmpty().WithMessage("Car is required.")
            .MustAsync(CarExists).WithMessage("Car is not valid.");
            ;
    }

    private async Task<bool> CarExists(int carId, CancellationToken token)
    {
        //_
        throw new NotImplementedException();
    }
}
