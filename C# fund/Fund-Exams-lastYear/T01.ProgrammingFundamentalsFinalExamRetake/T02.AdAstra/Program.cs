using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, Product> products = new Dictionary<string, Product>();
            string input = Console.ReadLine();
            //string strPattern = @"([\|#])(?<product>[A-Za-z\s]+)\1(?<date>[\d]{2}\/[\d]{2}\/[\d]{2})\1(?<calories>\d{1,5})\1";
            string strPattern = @"([|#])(?<product>[A-Za-z\s]+)\1(?<date>[\d]{2}\/[\d]{2}\/[\d]{2})\1(?<calories>\d+)\1";
            MatchCollection matches = Regex.Matches(input, strPattern);
            int totalCalories = 0;
            foreach (Match match in matches)
            {
                //string productName = match.Groups["product"].Value;
                //string date = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);
                totalCalories += calories;
                //  Product product = new Product(date, calories);
                // products[productName] = product;
            }
            int days = totalCalories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            //foreach (var product in products)
            //{
            //    Console.WriteLine($"Item: {product.Key}, Best before: {product.Value.Date}, Nutrition: {product.Value.Calories}");
            //}
            foreach (Match match in matches)
            {
                string productName = match.Groups["product"].Value;
                string date = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);
                Console.WriteLine($"Item: {productName}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
    //class Product
    //{
    //    public Product(string date, int calories)
    //    {
    //        this.Date = date;
    //        this.Calories = calories;
    //    }
    //    public string Date { get; set; }
    //    public int Calories { get; set; }

    //}
}
