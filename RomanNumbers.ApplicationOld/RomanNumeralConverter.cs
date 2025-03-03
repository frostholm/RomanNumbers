using System.Text.RegularExpressions;

namespace RomanNumbers
{
    public class RomanNumeralConverter
    {
        private static readonly Dictionary<char,decimal> RomanNumeralValues = new() { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 10000 }, };
        private static readonly List<char> NoneRepeateable = new() { 'V','L','D' };
        //public static decimal ConvertToDecimal(string romanNumeral)
        //{
        //    decimal result = 0;


        //    if(!Validate(romanNumeral))
        //        Console.WriteLine("Validation failed");




        //    return result;
        //}

        //private static bool Validate(string romanNumeral)
        //{
        //    bool valid = true;
        //    char[] chars = romanNumeral.ToCharArray();
        //    int numbeberOfEquals = 1;

        //    for(int i = 0; i < chars.Length-1; i++)
        //    {
        //        var c = chars[i];
        //        if (!RomanNumeralValues.ContainsKey(c))
        //            throw new InvalidCharacterException();

        //        var next = chars[i+1];

                
        //        if (c == next)
        //        {
        //            numbeberOfEquals++;


        //            if (NoneRepeateable.Contains(c))
        //            {
        //                throw new InvalidCharacterFollowingExeption(String.Format("A {0} can never be repeated by another {0}, postion {1}", c.ToString(), i + 2));
        //            } 
        //            else if (numbeberOfEquals > 3)
        //            {
        //                throw new InvalidCharacterFollowingExeption("The same character can not be repeated 4 times");
        //            }
        //        }

        //        else
        //        {

        //            if (RomanNumeralValues[c] < RomanNumeralValues[next])
        //            {
        //                if (c == 'I' && (next != 'V' && next != 'X'))
        //                    throw new InvalidCharacterFollowingExeption(String.Format("Only a V or X can follow a I, postion {0}", i + 2));

        //                if (c == 'X' && (next != 'L' && next != 'C'))
        //                    throw new InvalidCharacterFollowingExeption(String.Format("Only a L or C can follow a X, postion {0}", i + 2));

        //                if (c == 'C' && (next != 'D' && next != 'M'))
        //                    throw new InvalidCharacterFollowingExeption(String.Format("Only a D or V can follow a C, postion {0}", i + 2));
        //            }

        //            numbeberOfEquals = 0;
        //        }


        //    }

        //    return valid;
        //}

        private static readonly Regex RomanRegex = new Regex(
        "^(M{0,3})(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static bool IsValidRomanNumeral(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return RomanRegex.IsMatch(input);
        }
    }
}
