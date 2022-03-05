using System;

namespace _1._2___Movie_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double pricePerTicket = double.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());

            double totalIncomePerDay = tickets * pricePerTicket;
            double totalIncome = totalIncomePerDay * days;
            double rent = totalIncome * percent / 100.0;

            double totalWin = totalIncome - rent;
            Console.WriteLine($"The profit from the movie {name} is {totalWin:F2} lv.");
        }
    }
}
