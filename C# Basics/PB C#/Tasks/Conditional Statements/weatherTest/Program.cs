using System;

namespace Even_or_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
            string weather = Console.ReadLine();
            if (weather == "sunny")
            {
                Console.WriteLine("The weather is nice");
            }


            else if (weather == "rainy")
            {
                Console.WriteLine("Take an umbrella!");

            }

            else if (weather == "snowy")
            {
                Console.WriteLine("Go skiing");
            }

            else if (weather == "windy")
            {
                Console.WriteLine("Wear a coat!");
            }
            else
            {
                Console.WriteLine("Invalid weather!");
            }

        }
    }
}
