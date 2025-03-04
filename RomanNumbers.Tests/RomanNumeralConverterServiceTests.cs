using RomanNumbers.Application.Services;

namespace RomanNumbers.Tests;

[TestClass]
public class RomanNumeralConverterServiceTests
{
    private RomanNumeralConverterService _service;

    [TestInitialize]
    public void Setup()
    {
        _service = new RomanNumeralConverterService();
    }

    [TestMethod]
    [DataRow(1, "I")]
    [DataRow(4, "IV")]
    [DataRow(9, "IX")]
    [DataRow(58, "LVIII")]
    [DataRow(1994, "MCMXCIV")]
    [DataRow(2999, "MMCMXCIX")]
    public void ConvertToRoman_ValidNumbers_ReturnsExpectedRomanNumerals(int number, string expected)
    {
        var result = _service.ConvertToRoman(number);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow("I", 1)]
    [DataRow("IV", 4)]
    [DataRow("IX", 9)]
    [DataRow("LVIII", 58)]
    [DataRow("MCMXCIV", 1994)]
    [DataRow("MMCMXCIX", 2999)]
    public void ConvertToDecimal_ValidRomanNumerals_ReturnsExpectedNumbers(string roman, int expected)
    {
        var result = _service.ConvertToDecimal(roman);
        Assert.AreEqual(expected, result);
    }
}
