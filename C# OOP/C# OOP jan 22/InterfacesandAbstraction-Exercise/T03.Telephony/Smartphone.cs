using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Telephony
{
    public class Smartphone : ISmartphone, IPhone
    {
        private string number;
        private string site;
        public Smartphone(string number, bool x = true)
        {
            this.number = number;
        }
        public Smartphone(string site)
        {
            this.site = site;
        }
        public void CallPhones()
        {
            Console.WriteLine($"Calling... {number}");
        }
        public void BrowseInWWW()
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
