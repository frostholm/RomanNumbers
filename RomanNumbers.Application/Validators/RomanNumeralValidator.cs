using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RomanNumbers.Validators
{
    public class RomanNumeralValidator
    {
        private static readonly Regex RomanRegex = new Regex(
          "^(M{0,3})(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string ValidateRomanNumeral(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Input cannot be empty or whitespace.";

            if (!Regex.IsMatch(input, "^[IVXLCDM]+$", RegexOptions.IgnoreCase))
                return "Input contains invalid characters. Only I, V, X, L, C, D, and M are allowed.";

            if (!RomanRegex.IsMatch(input))
            {
                if (Regex.IsMatch(input, "IIII|XXXX|CCCC|MMMM"))
                    return "Invalid repetition of I, X, C, or M. They can only appear up to three times in a row.";
                if (Regex.IsMatch(input, "VV|LL|DD"))
                    return "Invalid repetition of V, L, or D. These symbols cannot be repeated.";
                if (Regex.IsMatch(input, "IL|IC|ID|IM|VX|VL|VC|VD|VM|XD|XM|LC|LD|LM|DM"))
                    return "Invalid subtraction pattern.";
                return "Invalid Roman numeral format.";
            }

            return "Valid Roman numeral.";
        }
    }
}
