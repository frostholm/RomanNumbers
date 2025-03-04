﻿using FluentValidation;
using RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromDecimalToRoman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromRomanToDecimal
{
    public class GetFromDecimalToRomanQueryValidator : AbstractValidator<GetFromRomanToDecimalQuery>
    {
        public GetFromDecimalToRomanQueryValidator()
        {
            RuleFor(p => p.RomanInput)
                .NotEmpty().WithMessage("Input cannot be empty or whitespace.")
                .Matches("^[IVXLCDM]+$").WithMessage("Input contains invalid characters. Only I, V, X, L, C, D, and M are allowed.")
                .Must(BeValidStructure).WithMessage("Invalid Roman numeral structure.")
                .Must(NotHaveInvalidRepetitions).WithMessage("Invalid repetition of Roman numeral characters.")
                .Must(NotHaveInvalidSubtractions).WithMessage("Invalid subtraction pattern in Roman numeral.");
        }

        private bool BeValidStructure(string input)
        {
            var romanRegex = new Regex(
                "^(M{0,3})(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$",
                RegexOptions.IgnoreCase);
            return romanRegex.IsMatch(input);
        }

        private bool NotHaveInvalidRepetitions(string input)
        {
            return !Regex.IsMatch(input, "IIII|XXXX|CCCC|MMMM|VV|LL|DD");
        }

        private bool NotHaveInvalidSubtractions(string input)
        {
            return !Regex.IsMatch(input, "IL|IC|ID|IM|VX|VL|VC|VD|VM|XD|XM|LC|LD|LM|DM");
        }
    }
}

