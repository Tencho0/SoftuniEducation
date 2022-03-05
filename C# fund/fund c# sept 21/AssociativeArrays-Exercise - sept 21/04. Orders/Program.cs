using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string name = string.Empty;
            decimal price = 0;
            decimal quantity = 0;
            Dictionary<string, decimal> productQuantity = new Dictionary<string, decimal>();
            Dictionary<string, decimal> productPrice = new Dictionary<string, decimal>();
            Dictionary<string, decimal> productTotalPrice = new Dictionary<string, decimal>();
            while (command.ToLower() != "buy")
            {
                decimal totalPrice = 0;
                string[] givenCommands = command.Split();
                name = givenCommands[0];
                price = decimal.Parse(givenCommands[1]);
                quantity = decimal.Parse(givenCommands[2]);
                if (!productQuantity.ContainsKey(name))
                {
                    productQuantity.Add(name, quantity);
                    productPrice.Add(name, price);
                }
                else
                {
                    productPrice[name] = price;
                    productQuantity[name] += quantity;
                }
                totalPrice = productQuantity[name] * productPrice[name];
                productTotalPrice[name] = totalPrice;
                command = Console.ReadLine();
            }
            foreach (var everyProduct in productTotalPrice)
            {
                Console.WriteLine($"{everyProduct.Key} -> {everyProduct.Value:f2}");
            }
        }
    }
}
