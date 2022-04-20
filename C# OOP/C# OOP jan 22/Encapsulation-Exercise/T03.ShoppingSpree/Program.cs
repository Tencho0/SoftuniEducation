using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {
                string[] givenPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (string currPerson in givenPeople)
                {
                    string[] data = currPerson.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = data[0];
                    decimal money = decimal.Parse(data[1]);
                    Person person = new Person(name, money);
                    people[name] = person;
                }

                string[] givenProducts = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (string currProduct in givenProducts)
                {
                    string[] data = currProduct.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = data[0];
                    decimal price = decimal.Parse(data[1]);
                    Product person = new Product(name, price);
                    products[name] = person;
                }

                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string personName = givenCmd[0];
                    string productName = givenCmd[1];

                    Person person = people[personName];
                    Product product = products[productName];

                    if (person.Money < product.Cost)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        person.Money -= product.Cost;
                        person.BagOfProducts.Add(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }

                    command = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    if (person.Value.BagOfProducts.Count == 0)
                    {
                        Console.WriteLine($"{person.Key} - Nothing bought");
                        continue;
                    }

                    Console.WriteLine($"{person.Key} - {string.Join(", ", person.Value.BagOfProducts.Select(x => x.Name))}");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
