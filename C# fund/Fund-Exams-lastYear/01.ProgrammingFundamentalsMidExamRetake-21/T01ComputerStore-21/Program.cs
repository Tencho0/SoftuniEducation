using System;

namespace T01ComputerStore_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string givenCommand = Console.ReadLine();
            double totalPriceWithoutTaxes = 0;
            while (givenCommand != "special" && givenCommand != "regular")
            {
                double currPrice = double.Parse(givenCommand);
                if (currPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    totalPriceWithoutTaxes += currPrice;
                }
                givenCommand = Console.ReadLine();
            }
            if (totalPriceWithoutTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                double totalAmountOfTaxes = totalPriceWithoutTaxes * 0.2;
                double totalPriceWithTaxesAndDiscount = totalPriceWithoutTaxes + totalAmountOfTaxes;
                if (givenCommand == "special")
                {
                    totalPriceWithTaxesAndDiscount *= 0.9;
                }
                Console.WriteLine($"Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPriceWithoutTaxes:f2}$");
                Console.WriteLine($"Taxes: {totalAmountOfTaxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPriceWithTaxesAndDiscount:f2}$");
            }
        }
    }
}
