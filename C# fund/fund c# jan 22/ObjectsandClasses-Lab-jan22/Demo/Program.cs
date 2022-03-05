using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Sharo", "Husky", 7);
            Dog pirincho = new Dog("Pirincho", "Pitbull", 5);
            Dog balkan = new Dog();
            dog.SayHi();
            Console.WriteLine();
            pirincho.SayHi();
            Console.WriteLine();
            balkan.SayHi();
        }
    }
}
