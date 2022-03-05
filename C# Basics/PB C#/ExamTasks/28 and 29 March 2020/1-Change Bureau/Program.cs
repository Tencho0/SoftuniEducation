using System;

namespace _1_Change_Bureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double ioan = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            double bitcoinsLeva = bitcoins * 1168;
            double ioanDolar = ioan * 0.15;
            double ioanDolarLeva = ioanDolar * 1.76;

            double totalLeva = bitcoinsLeva + ioanDolarLeva;
            double totalEuro = totalLeva / 1.95;
            double totalCommission = commission / 100 * 1.0;
            double totalMoneyCommission = totalEuro * totalCommission;
            double totalMoney = totalEuro - totalMoneyCommission;
            Console.WriteLine($"{totalMoney:F2}");
        }
    }
}
