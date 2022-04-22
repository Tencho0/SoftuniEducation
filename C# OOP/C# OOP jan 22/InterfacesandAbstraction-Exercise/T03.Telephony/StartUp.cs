using System;
using System.Linq;

namespace T03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in phoneNums)
            {
                bool isValid = true;
                foreach (var digit in number)
                {
                    if (!char.IsDigit(digit))
                    {
                        Console.WriteLine("Invalid number!");
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    IPhone phone;
                    if (number.Length == 10)
                    {
                        phone = new Smartphone(number, true);
                    }
                    else
                    {
                        phone = new StationaryPhone(number);
                    }
                    phone.CallPhones();
                }
            }

            foreach (var site in websites)
            {
                if (site.Any(x=> char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                ISmartphone smartphone = new Smartphone(site);
                smartphone.BrowseInWWW();
            }
        }
    }
}
