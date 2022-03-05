using System;

namespace T01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double totalPrice = 0;
            while (command != "special" && command != "regular")
            {
                double price = double.Parse(command);
                if (price <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    totalPrice += price;
                }
                command = Console.ReadLine();
            }
            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                double taxes = totalPrice * 0.2;
                double totalPriceWithTaxes = totalPrice + taxes;
                if (command == "special")
                {
                    totalPriceWithTaxes *= 0.9;
                }
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:F2}$");
                Console.WriteLine($"Taxes: {taxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPriceWithTaxes:F2}$");
            }
        }
    }
}
