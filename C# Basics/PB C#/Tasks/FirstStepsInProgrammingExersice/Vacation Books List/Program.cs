using System;

namespace Vacation_Books_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double hoursPerDay = pages / pagesPerHour / days;
            Console.WriteLine(hoursPerDay);
        }
    }
}
