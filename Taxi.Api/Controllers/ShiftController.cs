using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taxi.Aplication.Features.Shifts.Queries.GetShiftsList;

namespace Taxi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftController : Controller
    {
        private readonly IMediator _mediator;

        public ShiftController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetShiftByUserId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ShiftListVm>>> GetShiftByUserId(int userId)
        {
            var getShiftsListQuery = new GetShiftsListQuery() { UserId = userId };
            var result = await _mediator.Send(getShiftsListQuery);
            return Ok(result);
        }
    }
}
