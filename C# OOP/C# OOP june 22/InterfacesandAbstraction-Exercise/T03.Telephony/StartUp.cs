using System;

namespace T03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ICallable phone = null;
            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 10)
                        phone = new Smartphone();
                    else if (number.Length == 7)
                        phone = new StationaryPhone();

                    Console.WriteLine(phone.Call(number));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            IBrowsable modernPhone = new Smartphone();
            foreach (var website in websites)
            {
                try
                {
                    Console.WriteLine(modernPhone.Browse(website));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
