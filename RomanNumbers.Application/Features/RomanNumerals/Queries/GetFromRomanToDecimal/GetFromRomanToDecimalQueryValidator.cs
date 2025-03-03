using FluentValidation;
using RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromRomanToDecimal
{
    public class GetFromDecimalToRomanQueryValidator : AbstractValidator<GetFromRomanToDecimalQuery>
    {
        public GetFromDecimalToRomanQueryValidator()
        {
            RuleFor(p => p.RomanInput)
                .NotEmpty();
            
        }
    }
}
