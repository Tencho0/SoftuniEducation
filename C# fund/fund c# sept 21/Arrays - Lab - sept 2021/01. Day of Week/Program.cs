using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            double n = double.Parse(Console.ReadLine());
            if (n <= 7 && n >= 1)
            {
                int num = (int)(n);
                Console.WriteLine(days[num-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
