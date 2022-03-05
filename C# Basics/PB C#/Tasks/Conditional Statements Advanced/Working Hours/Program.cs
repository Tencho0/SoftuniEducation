using System;

namespace Working_Hours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday" || day == "Saturday")
            {
                if (hour >= 10 && hour <= 18)
                {
                    Console.WriteLine("open");
                }
                else if(!(hour > 10 && hour < 18))
                {
                    Console.WriteLine("closed");
                }
            }

            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}
