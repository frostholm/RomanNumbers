using FluentValidation;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromIntToRoman
{
    public class GetFromIntToRomanQueryValidator : AbstractValidator<GetFromIntToRomanQuery>
    {
        public GetFromIntToRomanQueryValidator()
        {
            RuleFor(p => p.Input)
                .GreaterThan(0)
                .LessThan(3000);

        }
    }
}
