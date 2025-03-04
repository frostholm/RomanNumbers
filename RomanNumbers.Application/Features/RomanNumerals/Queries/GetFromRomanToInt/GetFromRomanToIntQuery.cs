using MediatR;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromRomanToInt
{
    public class GetFromRomanToIntQuery : IRequest<int>
    {
        public string RomanInput { get; set; }
    }
}
