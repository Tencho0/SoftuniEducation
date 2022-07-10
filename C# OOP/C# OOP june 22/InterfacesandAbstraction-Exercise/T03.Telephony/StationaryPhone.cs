using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            foreach (var digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    throw new Exception($"Invalid number!");
                }
            }
            return $"Dialing... {number}";
        }
    }
}
