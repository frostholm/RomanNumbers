using MediatR;
using RomanNumbers.Application.Services;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromRomanToInt
{
    public class GetFromRomanToIntQueryHandler : IRequestHandler<GetFromRomanToIntQuery, int>
    {
        private readonly IRomanNumeralConverterService _converterService;

        public GetFromRomanToIntQueryHandler(IRomanNumeralConverterService converterService)
        {
            _converterService = converterService;
        }

        public Task<int> Handle(GetFromRomanToIntQuery request, CancellationToken cancellationToken)
        {
            var result = _converterService.ConvertToDecimal(request.RomanInput);
            return Task.FromResult(result);
        }

    }
}
