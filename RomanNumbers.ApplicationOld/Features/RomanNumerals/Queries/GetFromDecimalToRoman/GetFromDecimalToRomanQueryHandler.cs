using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman
{
    public class GetFromDecimalToRomanQueryHandler : IRequestHandler<GetFromDecimalToRomanQuery, string>
    {
        public Task<string> Handle(GetFromDecimalToRomanQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }
}
