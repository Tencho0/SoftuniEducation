using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int CONSUMED_BY_WORKERS = 26;
            int spices = int.Parse(Console.ReadLine());
            int days = 0;
            int totalSpices = 0;
            while (spices >= 100)
            {
                totalSpices += spices - CONSUMED_BY_WORKERS;
                spices -= 10;
                days++;
                if (spices < 100)
                {
                    totalSpices -= CONSUMED_BY_WORKERS;
                }
            }
            Console.WriteLine(days);
            Console.WriteLine(totalSpices);




            //int num = int.Parse(Console.ReadLine());
            //if (num >= 100)
            //{
            //    int days = 0;
            //    int totalSpices = 0;
            //    while (num >= 100)
            //    {
            //        totalSpices += num;
            //        days++;
            //        num -= 10;
            //    }
            //    days++;
            //    totalSpices -= (26 * days);
            //    Console.WriteLine(days - 1);
            //    Console.WriteLine(totalSpices);
            //}
            //else
            //{
            //    Console.WriteLine(0);
            //    Console.WriteLine(0);
            //}
        }
    }
}
