using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers.Exceptions
{

    public class InvalidCharacterFollowingExeption : Exception
    {
        public InvalidCharacterFollowingExeption()
            : base() 
        {
        }

        public InvalidCharacterFollowingExeption(string message)
            : base(message)
        {
        }

        public InvalidCharacterFollowingExeption(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
