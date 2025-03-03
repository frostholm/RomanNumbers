using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman
{
    public class GetFromRomanToDecimalQueryHandler : IRequestHandler<GetFromRomanToDecimalQuery, decimal>
    {
        public Task<decimal> Handle(GetFromRomanToDecimalQuery request, CancellationToken cancellationToken)
        {
            decimal result = 100;
            return Task.FromResult(result);
        }
    }
}
