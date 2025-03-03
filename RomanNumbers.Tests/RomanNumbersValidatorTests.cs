using RomanNumbers.Validators;

namespace RomanNumbers.Tests
{
    [TestClass]
    public class RomanNumeralValidatorTests
    {
        [TestMethod]
        public void Test_ValidRomanNumerals()
        {
            Assert.AreEqual("Valid Roman numeral.", RomanNumeralValidator.ValidateRomanNumeral("XIV"));
            Assert.AreEqual("Valid Roman numeral.", RomanNumeralValidator.ValidateRomanNumeral("MMMCMXCIX"));
            Assert.AreEqual("Valid Roman numeral.", RomanNumeralValidator.ValidateRomanNumeral("CDXLIV"));
            Assert.AreEqual("Valid Roman numeral.", RomanNumeralValidator.ValidateRomanNumeral("MCMXCIV"));
        }

        [TestMethod]
        public void Test_InvalidRomanNumerals()
        {
            Assert.AreEqual("Input contains invalid characters. Only I, V, X, L, C, D, and M are allowed.", RomanNumeralValidator.ValidateRomanNumeral("ABC"));
            Assert.AreEqual("Invalid repetition of I, X, C, or M. They can only appear up to three times in a row.", RomanNumeralValidator.ValidateRomanNumeral("IIII"));
            Assert.AreEqual("Invalid subtraction pattern.", RomanNumeralValidator.ValidateRomanNumeral("IC"));
            Assert.AreEqual("Invalid subtraction pattern.", RomanNumeralValidator.ValidateRomanNumeral("VX"));
            Assert.AreEqual("Invalid repetition of I, X, C, or M. They can only appear up to three times in a row.", RomanNumeralValidator.ValidateRomanNumeral("MMMM"));
        }

        [TestMethod]
        public void Test_EmptyOrWhitespaceInput()
        {
            Assert.AreEqual("Input cannot be empty or whitespace.", RomanNumeralValidator.ValidateRomanNumeral(""));
            Assert.AreEqual("Input cannot be empty or whitespace.", RomanNumeralValidator.ValidateRomanNumeral(" "));
        }
    }
}
