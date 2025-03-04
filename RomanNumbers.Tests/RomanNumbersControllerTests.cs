using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RomanNumbers.API.Controllers;
using RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromRomanToInt;
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbers.Application.Features.RomanNumerals.Queries.GetFromIntToRoman;

namespace RomanNumbers.Tests
{
    [TestClass]
    public class RomanNumbersControllerTests
    {
        private Mock<ILogger<RomanNumbersController>> _loggerMock;
        private Mock<IMediator> _mediatorMock;
        private RomanNumbersController _controller;

        [TestInitialize]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<RomanNumbersController>>();
            _mediatorMock = new Mock<IMediator>();
            _controller = new RomanNumbersController(_loggerMock.Object, _mediatorMock.Object);
        }

        [TestMethod]
        [DataRow(1, "I")]
        [DataRow(4, "IV")]
        [DataRow(9, "IX")]
        [DataRow(58, "LVIII")]
        [DataRow(1994, "MCMXCIV")]
        [DataRow(2999, "MMCMXCIX")]

        [DataRow(1999, "MCMXCIX")]
        [DataRow(2444, "MMCDXLIV")]
        [DataRow(90, "XC")]
        public async Task ConvertFromIntegerToRoman_ValidIntger_ReturnsExpectedRomanNumber(int number, string expectedResult)
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetFromIntToRomanQuery>(), default))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.ConvertFromIntegerToRoman(number);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult, okResult.Value);
        }

        [TestMethod]
        [DataRow("I", 1)]
        [DataRow("IV", 4)]
        [DataRow("IX", 9)]
        [DataRow("LVIII", 58)]
        [DataRow("MCMXCIV", 1994)]
        [DataRow("MMCMXCIX", 2999)]
        
        [DataRow("MCMXCIX", 1999)]
        [DataRow("MMCDXLIV", 2444)]
        [DataRow("XC", 90)]
        public async Task ConvertFromRomanToInteger_ValidRomanNumber_ReturnsExpectedInteger(string romanNumber, int expectedResult)
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetFromRomanToIntQuery>(), default))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.ConvertFromRomanToInteger(romanNumber);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult, okResult.Value);
        }
    }
}