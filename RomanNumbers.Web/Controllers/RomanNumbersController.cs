using MediatR;
using Microsoft.AspNetCore.Mvc;
using RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman;
using RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromRomanToInt;

namespace RomanNumbers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RomanNumbersController : ControllerBase
    {

        private readonly ILogger<RomanNumbersController> _logger;
        private IMediator _mediator { get; }

        public RomanNumbersController(ILogger<RomanNumbersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("/convert-from-roman-to-integer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> ConvertFromRomanToInteger([FromQuery] string romanNumber)
        {
            var response = await _mediator.Send(new GetFromRomanToIntQuery() { RomanInput = romanNumber });
            return Ok(response);
        }

        [HttpGet("/convert-from-integer-to-roman")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> ConvertFromIntegerToRoman([FromQuery] int number)
        {
            var response = await _mediator.Send(new GetFromDecimalToRomanQuery() { DecimalInput = number });
            return Ok(response);
        }

    }
}
