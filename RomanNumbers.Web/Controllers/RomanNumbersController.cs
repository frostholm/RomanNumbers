using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman;
using System.Net.NetworkInformation;

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

        [HttpGet("/convert-from-roman-to-decimal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> ConvertFromRomanToDecimal([FromQuery] string romanNumber)
        {
            var response = await _mediator.Send(new GetFromRomanToDecimalQuery() { RomanInput = romanNumber });
            return Ok(response);
        }

        [HttpGet("/convert-from-decimal-to-roman")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> ConvertFromDecimalToRoman([FromRoute] decimal number)
        {
            var response = await _mediator.Send(new GetFromDecimalToRomanQuery() { DecimalInput = number });
            return Ok(response);
        }

    }
}
