using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();
            string command = Console.ReadLine();
            while (command != "Revision")
            {
                string[] givenCmd = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shopName = givenCmd[0];
                string product = givenCmd[1];
                double price = double.Parse(givenCmd[2]);

                if (!shops.ContainsKey(shopName))
                    shops[shopName] = new Dictionary<string, double>();
                shops[shopName][product] = price;

                command = Console.ReadLine();
            }

            foreach (var (shop, products) in shops.OrderBy(x=> x.Key))
            {
                Console.WriteLine($"{shop}->");
                foreach (var (product, price) in products)
                    Console.WriteLine($"Product: {product}, Price: {price}");
            }
        }
    }
}
