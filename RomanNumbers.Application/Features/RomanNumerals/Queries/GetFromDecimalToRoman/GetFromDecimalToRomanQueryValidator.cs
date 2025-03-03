using FluentValidation;
using RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman
{
    public class GetFromDecimalToRomanQueryValidator : AbstractValidator<GetFromDecimalToRomanQuery>
    {
        public GetFromDecimalToRomanQueryValidator()
        {
            RuleFor(p => p.DecimalInput)
                .GreaterThan(0)
                .LessThan(3000);
            
        }
    }
}
