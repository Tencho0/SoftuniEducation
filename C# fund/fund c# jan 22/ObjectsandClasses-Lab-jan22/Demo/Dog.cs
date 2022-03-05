using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Dog
    {
        public Dog()
        {
            Name = "Balkan";
            Age = 3;
            Breed = "Retrivyr";
        }
        public Dog(string name, string breed, int age)
        {
            Name = name;
            Breed = breed;
            Age = age;
        }
        public string Name { get; set; }

        public string Breed{ get; set; }
        public int Age{ get; set; }

        public void SayHi()
        {
            Console.WriteLine($"Hi from {Name}!");
            Console.WriteLine($"Breed: {Breed}");
            Console.WriteLine($"Age: {Age}");
        }
    }
}
