using MediatR;
using RomanNumbers.Application.Services;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman
{
    public class GetFromDecimalToRomanQueryHandler : IRequestHandler<GetFromDecimalToRomanQuery, string>
    {
        private readonly IRomanNumeralConverterService _converterService;

        public GetFromDecimalToRomanQueryHandler(IRomanNumeralConverterService converterService)
        {
            _converterService = converterService;
        }
        public Task<string> Handle(GetFromDecimalToRomanQuery request, CancellationToken cancellationToken)
        {
            var result = _converterService.ConvertToRoman(request.DecimalInput);
            return Task.FromResult(result);
        }
    }
}
