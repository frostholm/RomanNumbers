// See https://aka.ms/new-console-template for more information



using RomanNumbers;
using RomanNumbers.Exceptions;
using RomanNumbers.Validators;

using static System.Net.Mime.MediaTypeNames;

//var Oktal = RomanNumeralConverter.ConvertToDecimal("IVXLCDM");


//var forkettal1 = RomanNumeralConverter.ConvertToDecimal("IIIVIX");

//var forkettal2 = RomanNumeralConverter.ConvertToDecimal("XXLXC");

//var forkettal3 = RomanNumeralConverter.ConvertToDecimal("CCDCM");


try
{
    //var forkettal3 = RomanNumeralConverter.ConvertToDecimal("IIIIMMMCCCXXX");
    //var forkettal3 = RomanNumeralConverter.ConvertToDecimal("XXI");
    //Console.WriteLine(RomanNumeralValidator.IsValidRomanNumeral("IVV"));
}
catch (NoneRepeateableCharacterException e)
{

    Console.WriteLine("Exception : " + e.Message);
}
catch (Exception e)
{

	Console.WriteLine("Exception : " + e.Message);
}

