using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers.Application.Services
{
    public class RomanNumeralConverterService : IRomanNumeralConverterService
    {
        public string ConvertToRoman(int number)
        {
            if ((number < 0) || (number > 3999))
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 1 and 3999.");
            }
            if (number < 1)
            {
                return string.Empty;
            }
            if (number >= 1000)
            {
                return "M" + ConvertToRoman(number - 1000);
            }
            if (number >= 900)
            {
                return "CM" + ConvertToRoman(number - 900);
            }
            if (number >= 500)
            {
                return "D" + ConvertToRoman(number - 500);
            }
            if (number >= 400)
            {
                return "CD" + ConvertToRoman(number - 400);
            }
            if (number >= 100)
            {
                return "C" + ConvertToRoman(number - 100);
            }
            if (number >= 90)
            {
                return "XC" + ConvertToRoman(number - 90);
            }
            if (number >= 50)
            {
                return "L" + ConvertToRoman(number - 50);
            }
            if (number >= 40)
            {
                return "XL" + ConvertToRoman(number - 40);
            }
            if (number >= 10)
            {
                return "X" + ConvertToRoman(number - 10);
            }
            if (number >= 9)
            {
                return "IX" + ConvertToRoman(number - 9);
            }
            if (number >= 5)
            {
                return "V" + ConvertToRoman(number - 5);
            }
            if (number >= 4)
            {
                return "IV" + ConvertToRoman(number - 4);
            }
            if (number >= 1)
            {
                return "I" + ConvertToRoman(number - 1);
            }
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 1 and 3999.");
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
