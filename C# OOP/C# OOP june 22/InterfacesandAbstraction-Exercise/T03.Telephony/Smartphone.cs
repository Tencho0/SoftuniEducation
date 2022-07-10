using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string URL)
        {
            foreach (var digit in URL)
            {
                if (char.IsDigit(digit))
                {
                    throw new Exception($"Invalid URL!");
                }
            }
            return $"Browsing: {URL}!";
        }

        public string Call(string number)
        {
            foreach (var digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    throw new Exception($"Invalid number!");
                }
            }
            return $"Calling... {number}"; 
        }
    }
}
