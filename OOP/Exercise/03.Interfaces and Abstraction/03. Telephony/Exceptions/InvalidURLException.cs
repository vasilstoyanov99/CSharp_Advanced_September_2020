﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string EXC_MSG = "Invalid URL!";

        public InvalidURLException()
            : base(EXC_MSG)

        {

        }

        public InvalidURLException(string message)
            : base(message)
        {

        }
    }
}
