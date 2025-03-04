using MediatR;
using RomanNumbers.Application.Services;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromIntToRoman
{
    public class GetFromIntToRomanQueryHandler : IRequestHandler<GetFromIntToRomanQuery, string>
    {
        private readonly IRomanNumeralConverterService _converterService;

        public GetFromIntToRomanQueryHandler(IRomanNumeralConverterService converterService)
        {
            _converterService = converterService;
        }
        public Task<string> Handle(GetFromIntToRomanQuery request, CancellationToken cancellationToken)
        {
            var result = _converterService.ConvertToRoman(request.Input);
            return Task.FromResult(result);
        }
    }
}
