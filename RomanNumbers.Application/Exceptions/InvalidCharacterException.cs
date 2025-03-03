using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers.Exceptions
{

    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException()
        {
        }

        public InvalidCharacterException(string message)
            : base(message)
        {
        }

        public InvalidCharacterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
