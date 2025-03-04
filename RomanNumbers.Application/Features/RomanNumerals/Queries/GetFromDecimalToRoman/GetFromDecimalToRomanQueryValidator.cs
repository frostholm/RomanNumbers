using FluentValidation;

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
