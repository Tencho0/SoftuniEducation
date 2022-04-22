using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Telephony
{
    public class StationaryPhone : IPhone
    {
        private string number;
        public StationaryPhone(string number)
        {
            this.number = number;
        }
        public void CallPhones()
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
