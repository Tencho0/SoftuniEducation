using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstCommand = Console.ReadLine();
            double currMoney = 0;
            while (firstCommand != "Start")
            {
                double coin = double.Parse(firstCommand);
                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    currMoney += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                firstCommand = Console.ReadLine();
            }

            string command2 = Console.ReadLine();
            double priceForProduct = 0;
            while (command2 != "End")
            {
                bool isValid = true;
                if (command2 == "Nuts")
                {
                    priceForProduct = 2;
                }
                else if (command2 == "Water")
                {
                    priceForProduct = 0.7;
                }
                else if (command2 == "Crisps")
                {
                    priceForProduct = 1.5;
                }
                else if (command2 == "Soda")
                {
                    priceForProduct = 0.8;
                }
                else if (command2 == "Coke")
                {
                    priceForProduct = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    isValid = false;
                }
                if (currMoney < priceForProduct && isValid)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else if (currMoney >= priceForProduct && isValid)
                {
                    Console.WriteLine($"Purchased {command2.ToLower()}");
                    currMoney -= priceForProduct;
                }
                command2 = Console.ReadLine();
            }
            Console.WriteLine($"Change: {currMoney:F2}");
        }
    }
}
