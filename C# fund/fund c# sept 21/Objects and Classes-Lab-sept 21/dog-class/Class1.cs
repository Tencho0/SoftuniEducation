using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dog_class
{
    class Dog
    {
        public Dog (string name, string breed, int age)
        {
            Name = name;
            Breed = breed;
            Age = age;
        }
        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public void SayHi()
        {
            Console.WriteLine("Hi from Dog!");
            Console.WriteLine($"My name is: {Name}, Breed: {Breed}");
            Console.WriteLine("Bye!");
            Console.WriteLine();
        }

        public static void Bark()
        {

        }
    }
}
