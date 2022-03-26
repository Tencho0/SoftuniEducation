using System;

namespace _02._DoggyLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string dogBreed = Console.ReadLine();
            string gender = Console.ReadLine();

            int months = 2;
            if (dogBreed == "Shepherd")
            {
                if (gender == "m")
                {
                    months *= 13; 
                }
                else if (gender == "f")
                {
                    months *= 14;
                }
            }
            else if (dogBreed == "Shih Tzu")
            {
                if (gender == "m")
                {
                    months *= 15;
                }
                else if (gender == "f")
                {
                    months *= 16;
                }
            }
            else if (dogBreed == "Pitbull")
            {
                if (gender == "m")
                {
                    months *= 14;
                }
                else if (gender == "f")
                {
                    months *= 15;
                }
            }
            else if (dogBreed == "Poodle")
            {
                if (gender == "m")
                {
                    months *= 16;
                }
                else if (gender == "f")
                {
                    months *= 17;
                }
            }
            else if (dogBreed == "Samoyed")
            {
                if (gender == "m")
                {
                    months *= 12;
                }
                else if (gender == "f")
                {
                    months *= 13;
                }
            }
            else if (dogBreed == "Husky")
            {
                if (gender == "m")
                {
                    months *= 11;
                }
                else if (gender == "f")
                {
                    months *= 12;
                }
            }
            else
            {
                Console.WriteLine("Invalid dog breed!");
                    return;
            }

            Console.WriteLine($"{months} dog months");
        }
    }
}
