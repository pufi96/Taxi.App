using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Taxi.Aplication.Contracts.Persistence;
using Taxi.Domain.Entities;

namespace Taxi.Aplication.Features.Shifts.Commands.StartShift;
public class StartShiftCommandHandler : IRequestHandler<StartShiftCommand, StartShiftCommandResponse>
{
    private readonly IShiftRepository _eventRepository;
    private readonly IMapper _mapper;
    //private readonly IEmailService _emailService;
    private readonly ILogger<StartShiftCommandHandler> _logger;

    public StartShiftCommandHandler(IShiftRepository eventRepository, IMapper mapper, ILogger<StartShiftCommandHandler> logger)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<StartShiftCommandResponse> Handle(StartShiftCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateShiftCommandValidator(_eventRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new Exceptions.ValidationException(validationResult);

        var @event = _mapper.Map<Shift>(request);

        @event = await _eventRepository.AddAsync(@event);
        var shift = _mapper.Map<StartShiftVm>(@event);
        //var email = new Email() { To = "gill@snowball.be", Body = $"A new event was created: {request}", Subject = "A new event was created" };

        //try
        //{
        //    await _emailService.SendEmail(email);
        //}
        //catch (Exception ex)
        //{
        //    //this shouldn't stop the API from doing else so this can be logged
        //    _logger.LogError($"Mailing about event {@event.EventId} failed due to an error with the mail service: {ex.Message}");
        //}

        return new StartShiftCommandResponse { Shift = shift};
    }
}
