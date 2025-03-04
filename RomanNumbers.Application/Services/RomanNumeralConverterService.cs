using System.Text;

namespace RomanNumbers.Application.Services
{
    public class RomanNumeralConverterService : IRomanNumeralConverterService
    {
        private static readonly Dictionary<int, string> RomanNumerals = new()
        {
            { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" },
            { 100, "C" }, { 90, "XC" }, { 50, "L" }, { 40, "XL" },
            { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" }
        };

        public string ConvertToRoman(int number)
        {
            var result = new StringBuilder();
            foreach (var kvp in RomanNumerals)
            {
                while (number >= kvp.Key)
                {
                    result.Append(kvp.Value);
                    number -= kvp.Key;
                }
            }
            return result.ToString();
        }

        public int ConvertToDecimal(string roman)
        {
            var result = 0;
            var lastValue = 0;
            foreach (var numeral in roman)
            {
                var value = RomanNumeralValue(numeral);
                result += value;
                if (value > lastValue)
                {
                    result -= 2 * lastValue;
                }
                lastValue = value;
            }
            return result;
        }

        private int RomanNumeralValue(char numeral)
        {
            return numeral switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException("Invalid Roman numeral character.", nameof(numeral)),
            };
        }
    }
}
