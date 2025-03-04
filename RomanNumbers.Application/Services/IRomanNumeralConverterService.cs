namespace RomanNumbers.Application.Services
{
    public interface IRomanNumeralConverterService
    {
        int ConvertToDecimal(string roman);
        string ConvertToRoman(int number);
    }
}