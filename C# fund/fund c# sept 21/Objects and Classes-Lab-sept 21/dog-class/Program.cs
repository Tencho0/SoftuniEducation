using System;

namespace dog_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Sharo", "Pitbul", 2);

            Dog dog2 = new Dog("Djoni", "Retrivyr", 3);
            dog.SayHi();
            dog2.SayHi();
        }
    }
}

