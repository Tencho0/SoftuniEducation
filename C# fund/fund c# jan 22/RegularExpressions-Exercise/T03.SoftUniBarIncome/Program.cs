using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>[\d]+)\|[^|$%.]*?(?<price>[\d]+[.]?[\d]+)?\$";
            // Dictionary<string, Person> people = new Dictionary<string, Person>();
            decimal totalIncome = 0;
            string command = Console.ReadLine();
            while (command != "end of shift")
            {
                //Match matches = Regex.Match(command, pattern);
                Regex regex = new Regex(pattern);
                bool isValid = regex.IsMatch(command);
                if (isValid)
                {
                    //Match matches = regex.Match(command);
                    //string name = matches.Groups["name"].Value;
                    //string product = matches.Groups["product"].Value;
                    //int count = int.Parse(matches.Groups["count"].Value);
                    //decimal pricePerOne = decimal.Parse(matches.Groups["price"].Value);
                    //Person person = new Person(name, product, count, pricePerOne);
                    //people.Add(name, person);
                    string name = regex.Match(command).Groups["name"].Value;
                    string product = regex.Match(command).Groups["product"].Value;
                    int quantity = int.Parse(regex.Match(command).Groups["count"].Value);
                    decimal price = decimal.Parse(regex.Match(command).Groups["price"].Value);
                    decimal totalPrice = price * quantity;
                    totalIncome += totalPrice;
                    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
                }
                    command = Console.ReadLine();
            }

            //decimal totalIncome = 0;
            //foreach (var person in people)
            //{
            //    Person currPerson = person.Value;
            //    decimal totalPrice = currPerson.PricePerProduct * currPerson.Count;
            //    totalIncome += totalPrice;
            //    Console.WriteLine($"{person.Key}: {currPerson.Product} - {totalPrice:f2}");
            //}
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
    //class Person
    //{
    //    public Person(string name, string product, int count, decimal pricePerProduct)
    //    {
    //        this.Name = name;
    //        this.Product = product;
    //        this.Count = count;
    //        this.PricePerProduct = pricePerProduct;
    //    }
    //    public string Name { get; set; }
    //    public string Product { get; set; }
    //    public int Count { get; set; }
    //    public decimal PricePerProduct { get; set; }

    //}
}
