using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numOfNights = int.Parse(Console.ReadLine());
            double pricePerNight = double.Parse(Console.ReadLine());
            int additionalExpensesPercent = int.Parse(Console.ReadLine());

            if (numOfNights > 7)
            {
                pricePerNight *= 0.95;
            }

            double priceForHousing = numOfNights * pricePerNight;

            double additionalExpenses = budget * additionalExpensesPercent / 100.0;

            double total = priceForHousing + additionalExpenses;

            if (total <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - total:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{total - budget:f2} leva needed.");
            }

        }
    }
}