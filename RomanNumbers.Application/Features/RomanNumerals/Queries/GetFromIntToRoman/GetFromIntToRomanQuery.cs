using MediatR;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromIntToRoman
{
    public class GetFromIntToRomanQuery : IRequest<string>
    {
        public int Input { get; set; }
    }
}
