using System;
using System.Collections.Generic;

namespace T04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
            string command = Console.ReadLine();
            while (command != "Revision")
            {
                string[] givenCmd = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = givenCmd[0];
                string product = givenCmd[1];
                double price = double.Parse(givenCmd[2]);
                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }
                shops[shop][product] = price;
                command = Console.ReadLine();
            }
            foreach (var currShop in shops)
            {
                Console.WriteLine($"{currShop.Key}->");
                foreach (var item in currShop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
