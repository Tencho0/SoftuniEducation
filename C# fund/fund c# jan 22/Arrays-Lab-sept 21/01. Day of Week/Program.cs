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
            if (n <= 0 || n > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                int num = (int)n - 1;
                Console.WriteLine(days[num]);
            }
        }
    }
}
