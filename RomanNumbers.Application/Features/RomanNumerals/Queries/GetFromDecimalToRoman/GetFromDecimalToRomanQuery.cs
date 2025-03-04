using MediatR;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman
{
    public class GetFromDecimalToRomanQuery : IRequest<string>
    {
        public int DecimalInput { get; set; }
    }
}
