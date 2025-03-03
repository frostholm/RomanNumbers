using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman
{
    public class GetFromRomanToDecimalQuery : IRequest<decimal>
    {
        public string RomanInput { get; set; }
    }
}
