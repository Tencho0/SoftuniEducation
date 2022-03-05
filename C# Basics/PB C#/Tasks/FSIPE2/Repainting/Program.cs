using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int pain = int.Parse(Console.ReadLine());
            int tinner = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double nylonPrice = 1.5 * (nylon + 2);
            double paintPrice = 14.5 * (pain + 0.1 * pain);
            double tinnerPrice = 5.00 * tinner;
            double bagsPrice = 0.40;
            double materialsPrice = nylonPrice + paintPrice + tinnerPrice + bagsPrice;
            double hoursPrice = materialsPrice * 0.3 * hours;
            double finalSum = materialsPrice + hoursPrice;

            Console.WriteLine(finalSum);
            
        }
    }
}
