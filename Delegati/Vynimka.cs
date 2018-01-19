using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegati
{
    class TextNotInCorrectFormatException : Exception
    {
        public TextNotInCorrectFormatException()
        {
        }

        public TextNotInCorrectFormatException(string message) : base(message)
        {
        }
    }
}
