using System;
using System.Linq;
using T03.Telephony2.Contracts;
using T03.Telephony2.Exceptions;

namespace T03.Telephony2
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberException);
            }
            return number.Length > 7
                ? $"Calling... {number}"
                : $"Dialing... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidUrlException);
            }
            return $"Browsing: {url}!";
        }
    }
}
