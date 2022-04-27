namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    string[] animalData = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string[] foodData = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    IAnimal animal = AnimalFactory.CreateAnimal(animalData);
                    IFood food = FoodFactory.CreateFood(foodData);

                    FeedTheAnimal(animals, animal, food);
                }
                catch (Exception exeption)
                {
                    Console.WriteLine(exeption.Message);
                }

                command = Console.ReadLine();
            }
            PrintResult(animals);
        }

        public static void FeedTheAnimal(List<IAnimal> animals, IAnimal animal, IFood food)
        {
            if (animal != null && food != null)
            {
                animals.Add(animal);
                animal.AskForFood();
                animal.Eat(food);
            }
        }

        public static void PrintResult(List<IAnimal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
