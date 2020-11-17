using System.Linq;

using _03._Telephony.Exceptions;

namespace _03._Telephony.Model
{
    class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Dialing... {number}";
        }
    }
}
