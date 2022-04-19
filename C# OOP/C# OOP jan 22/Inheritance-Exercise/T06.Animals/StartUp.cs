using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Beast!")
                {
                    break;
                }
                string[] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                string name = animalData[0];
                int age = int.Parse(animalData[1]);

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Animal animal = default;
                if (command == "Dog")
                {
                    string gender = animalData[2];
                    animal = new Dog(name, age, gender);
                }
                else if (command == "Cat")
                {
                    string gender = animalData[2];
                    animal = new Cat(name, age, gender);
                }
                else if (command == "Frog")
                {
                    string gender = animalData[2];
                    animal = new Frog(name, age, gender);
                }
                else if (command == "Kitten")
                {
                    animal = new Kitten(name, age);
                }
                else if (command == "Tomcat")
                {
                    animal = new Tomcat(name, age);
                }

                Console.WriteLine($"{command}");
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
