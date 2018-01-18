using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegati
{
    class StringNotInCorrectFormatException : Exception
    {
        public StringNotInCorrectFormatException()
        {
        }

        public StringNotInCorrectFormatException(string message):base(message)
        {
        }
    }
}
