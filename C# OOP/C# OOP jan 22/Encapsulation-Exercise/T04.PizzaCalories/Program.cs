using System;

namespace T04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string pizzaName = pizzaInput[1];

                string[] doughInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string doughType = doughInput[1];
                string backingTechniques = doughInput[2];
                int doughWeight = int.Parse(doughInput[3]);

                Dough dough = new Dough(doughType, backingTechniques, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string ingredient = givenCmd[0];
                    string ingredientType = givenCmd[1];
                    int weight = int.Parse(givenCmd[2]);
                    Topping topping = new Topping(ingredientType, weight);
                    pizza.AddTopping(topping);
                    command = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
