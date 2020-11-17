using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Telephony.Model
{
    public interface ICallable
    {
        string Call(string number);
    }
}
