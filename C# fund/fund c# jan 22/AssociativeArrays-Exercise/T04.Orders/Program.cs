using System;
using System.Collections.Generic;

namespace T04.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string command = Console.ReadLine();
            while (command != "buy")
            {
                AddTheProduct(products, command);
                command = Console.ReadLine();
            }
            PrintTheResult(products);
        }
        static void AddTheProduct(Dictionary<string, Product> products, string command)
        {
            string[] givenCmd = command.Split();
            string product = givenCmd[0];
            decimal price = decimal.Parse(givenCmd[1]);
            decimal quantity = decimal.Parse(givenCmd[2]);
            if (!products.ContainsKey(product))
            {
                products[product] = new Product(product, price, quantity);
            }
            else
            {
                products[product].Price = price;
                products[product].Quantity += quantity;
                products[product].TotalPrice = products[product].Price * products[product].Quantity;
            }
        }
        static void PrintTheResult(Dictionary<string, Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.TotalPrice:F2}");
            }
        }
    }
    class Product
    {
        public Product(string name, decimal price, decimal quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            TotalPrice = Price * Quantity;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
