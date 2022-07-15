namespace T04.WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Factory;
    using Factory.Interfaces;
    using Model.Animals;
    using Model.Food;

    internal class Engine : IEngine
    {
        private List<Animal> animals;
        private IAnimalFactory animalFactory;
        private IFoodFactory foodFactory;
        public Engine()
        {
            animalFactory = new AnimalFactory();
            foodFactory = new FoodFactory();
            animals = new List<Animal>();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    string[] animalInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string[] foodInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Animal animal = CreateAnimal(animalInfo);
                    Food food = CreateFood(foodInfo);

                    this.animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var currAnimal in animals)
                Console.WriteLine(currAnimal);
        }

        private Food CreateFood(string[] foodInfo)
        {
            string foodType = foodInfo[0];
            int foodQuantity = int.Parse(foodInfo[1]);

            Food food;
            food = foodFactory.CreateFood(foodType, foodQuantity);

            return food;
        }

        private Animal CreateAnimal(string[] animalInfo)
        {
            Animal animal;
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            if (animalInfo.Length == 4)
                animal = animalFactory.CreateAnimal(type, name, weight, animalInfo[3]);
            else if (animalInfo.Length == 5)
                animal = animalFactory.CreateAnimal(type, name, weight, animalInfo[3], animalInfo[4]);
            else
                throw new ArgumentException("Invalid input!");

            return animal;
        }
    }
}
