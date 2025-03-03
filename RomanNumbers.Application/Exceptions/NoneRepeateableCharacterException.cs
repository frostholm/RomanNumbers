using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers.Exceptions
{

    public class NoneRepeateableCharacterException : Exception
    {
        public NoneRepeateableCharacterException()
        {
        }

        public NoneRepeateableCharacterException(string current, string next, int posistion)
            : base(String.Format("An {0} can not be follow by another {1}", current, next))
        {
        }

        public NoneRepeateableCharacterException(string current)
           : base(String.Format("An {0} can not be follow by another {0}", current))
        {
        }

        public NoneRepeateableCharacterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
