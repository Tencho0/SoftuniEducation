using System;

namespace _04._Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centturies = int.Parse(Console.ReadLine());
            int years = 100 * centturies;
            double days = Math.Floor(centturies * 36524.22);
            double hours = days * 24;
            double minutes = hours * 60;

            Console.WriteLine($"{centturies} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
