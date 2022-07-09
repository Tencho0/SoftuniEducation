using System;

namespace T04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = null;
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split();

                try
                {
                    switch (data[0])
                    {
                        case "Pizza":
                            pizza = new Pizza(data[1]);
                            break;
                        case "Dough":
                            pizza.AddDough(new Dough(data[1], data[2], int.Parse(data[3])));
                            break;
                        case "Topping":
                            pizza.AddTopping(new Topping(data[1], int.Parse(data[2])));
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(pizza);
        }
    }
}
















//using System;

//namespace T04.PizzaCalories
//{
//    public class StartUp
//    {
//        static void Main(string[] args)
//        {
//            string pizzaName = string.Empty;
//            string doughType = string.Empty;
//            string backingTechniques = string.Empty;
//            int doughWeight = 0;
//            Dough dough;
//            Pizza pizza = null;

//            string givenInput = Console.ReadLine();
//            while (givenInput != "END")
//            {
//                string[] givenCmd = givenInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//                string currCommand = givenCmd[0];

//                try
//                {
//                    if (currCommand == "Pizza")
//                    {
//                        pizzaName = givenCmd[1];
//                    }
//                    else if (currCommand == "Dough")
//                    {
//                        doughType = givenCmd[1];
//                        backingTechniques = givenCmd[2];
//                        doughWeight = int.Parse(givenCmd[3]);

//                        dough = new Dough(doughType, backingTechniques, doughWeight);
//                        pizza = new Pizza(pizzaName, dough);
//                    }
//                    else if (currCommand == "Topping")
//                    {
//                        string ingredient = givenCmd[0];
//                        string ingredientType = givenCmd[1];
//                        int weight = int.Parse(givenCmd[2]);
//                        Topping topping = new Topping(ingredientType, weight);
//                        pizza.AddTopping(topping);
//                    }
//                }
//                catch (Exception exception)
//                {
//                    Console.WriteLine(exception.Message);
//                    return;
//                }
//                givenInput = Console.ReadLine();
//            }
//            Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");













//            //     string[] pizzaInput = Console.ReadLine()
//            //     .Split(' ', StringSplitOptions.RemoveEmptyEntries);
//            //     string pizzaName = pizzaInput[1];
//            //    
//            //     string[] doughInput = Console.ReadLine()
//            //         .Split(' ', StringSplitOptions.RemoveEmptyEntries);
//            //     string doughType = doughInput[1];
//            //     string backingTechniques = doughInput[2];
//            //     int doughWeight = int.Parse(doughInput[3]);
//            //    
//            //     Dough dough = new Dough(doughType, backingTechniques, doughWeight);
//            //     Pizza pizza = new Pizza(pizzaName, dough);
//            //    
//            //     string command = Console.ReadLine();
//            //     while (command != "END")
//            //     {
//            //         string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//            //         string ingredient = givenCmd[0];
//            //         string ingredientType = givenCmd[1];
//            //         int weight = int.Parse(givenCmd[2]);
//            //         Topping topping = new Topping(ingredientType, weight);
//            //         pizza.AddTopping(topping);
//            //         command = Console.ReadLine();
//            //     }
//            //     Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
//        }
//    }
//}
