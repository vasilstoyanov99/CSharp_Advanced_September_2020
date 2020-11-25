using System;

namespace _07.Military_Elite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string DEF_EXC_MSG = "Invalid mission state!";

        public InvalidStateException()
            : base(DEF_EXC_MSG)
        {

        }

        public InvalidStateException(string message)
            : base(message)
        {

        }
    }
}
