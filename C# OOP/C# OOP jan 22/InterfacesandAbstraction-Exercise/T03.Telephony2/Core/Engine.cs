using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T03.Telephony2.Core
{
    public class Engine
    {
        private Smartphone smartphone;
        private IList<string> phoneNumbers;
        private IList<string> urls;

        public Engine()
        {
            this.smartphone = new Smartphone();
            this.phoneNumbers = new List<string>();
            this.urls = new List<string>();
        }
        public void Run()
        {
            this.phoneNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            
            this.urls = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            CallPhoneNumber();
            BrowseUrl();
        }

        private void CallPhoneNumber()
        {
            foreach (var phoneNumber in this.phoneNumbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(phoneNumber));
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        private void BrowseUrl()
        {
            foreach (var url in this.urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

    }
}
