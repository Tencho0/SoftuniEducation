using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, Person> people = new Dictionary<string, Person>();
                Dictionary<string, Product> products = new Dictionary<string, Product>();

                string[] givenPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                string[] givenProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var currPerson in givenPeople)
                {
                    string[] givenPerson = currPerson.Split('=');
                    string name = givenPerson[0];
                    decimal money = decimal.Parse(givenPerson[1]);
                    if (!people.ContainsKey(name))
                    {
                        Person person = new Person(name, money);
                        people.Add(name, person);
                    }
                }
                foreach (var currProduct in givenProducts)
                {
                    string[] givenProduct = currProduct.Split('=');
                    string name = givenProduct[0];
                    decimal money = decimal.Parse(givenProduct[1]);
                    if (!people.ContainsKey(name))
                    {
                        Product product = new Product(name, money);
                        products.Add(name, product);
                    }
                }

                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string personName = givenCmd[0];
                    string productName = givenCmd[1];

                    if (people.ContainsKey(personName))
                    {
                        if (people[personName].Money >= products[productName].Cost)
                        {
                            people[personName].Money -= products[productName].Cost;
                            people[personName].BagOfProducts.Add(products[productName]);
                            Console.WriteLine($"{personName} bought {productName}");
                        }
                        else
                        {
                            Console.WriteLine($"{personName} can't afford {productName}");
                        }
                    }

                    command = Console.ReadLine();
                }

                foreach (var currPerson in people)
                {
                    if (currPerson.Value.BagOfProducts.Count == 0)
                        Console.WriteLine($"{currPerson.Key} - Nothing bought");
                    else
                        Console.WriteLine($"{currPerson.Key} - {string.Join(", ", currPerson.Value.BagOfProducts.Select(x => x.Name))}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
