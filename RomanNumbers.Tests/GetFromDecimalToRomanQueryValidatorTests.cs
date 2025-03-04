using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromRomanToInt;

namespace RomanNumbers.Tests
{
    [TestClass]
    public class GetFromDecimalToRomanQueryValidatorTests
    {
        private GetFromRomanToIntQueryValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new GetFromRomanToIntQueryValidator();
        }

        [TestMethod]
        public void Should_Have_Error_When_RomanInput_Is_Empty()
        {
            var model = new GetFromRomanToIntQuery { RomanInput = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.RomanInput)
                  .WithErrorMessage("Input cannot be empty or whitespace.");
        }

        [TestMethod]
        public void Should_Have_Error_When_RomanInput_Has_Invalid_Characters()
        {
            var model = new GetFromRomanToIntQuery { RomanInput = "ABC" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.RomanInput)
                  .WithErrorMessage("Input contains invalid characters. Only I, V, X, L, C, D, and M are allowed.");
        }

        [TestMethod]
        public void Should_Have_Error_When_RomanInput_Has_Invalid_Structure()
        {
            var model = new GetFromRomanToIntQuery { RomanInput = "IIII" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.RomanInput)
                  .WithErrorMessage("Invalid Roman numeral structure.");
        }

        [TestMethod]
        [DataRow("VV")]
        [DataRow("LL")]
        [DataRow("DD")]
        [DataRow("IIII")]
        [DataRow("XXXX")]
        [DataRow("CCCC")]
        [DataRow("MMMM")]
        public void Should_Have_Error_When_RomanInput_Has_Invalid_Repetitions(string romanNumber)
        {
            var model = new GetFromRomanToIntQuery { RomanInput = romanNumber };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.RomanInput)
                  .WithErrorMessage("Invalid repetition of Roman numeral characters.");
        }

        [TestMethod]
        [DataRow("IL")]
        [DataRow("IC")]
        [DataRow("ID")]
        [DataRow("IM")]
        [DataRow("VX")]
        [DataRow("VL")]
        [DataRow("VC")]
        [DataRow("VD")]
        [DataRow("VM")]
        [DataRow("XD")]
        [DataRow("XM")]
        [DataRow("LC")]
        [DataRow("LD")]
        [DataRow("LM")]
        [DataRow("DM")]
        public void Should_Have_Error_When_RomanInput_Has_Invalid_Subtractions(string romanNumber)
        {
            var model = new GetFromRomanToIntQuery { RomanInput = romanNumber };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.RomanInput)
                  .WithErrorMessage("Invalid subtraction pattern in Roman numeral.");
        }

        [TestMethod]
        public void Should_Not_Have_Error_When_RomanInput_Is_Valid()
        {
            var model = new GetFromRomanToIntQuery { RomanInput = "XIV" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.RomanInput);
        }
    }
}