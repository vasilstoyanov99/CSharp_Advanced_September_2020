using System.Linq;

using _03._Telephony.Contracts;
using _03._Telephony.Exceptions;

namespace _03._Telephony.Model
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Browse(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {

            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {number}";
        }
    }
}
