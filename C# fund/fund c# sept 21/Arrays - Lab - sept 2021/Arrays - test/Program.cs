using System;
using System.Linq;

namespace Arrays___test
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"array{i}={array[i]}");
            }


            //int n = int.Parse(Console.ReadLine());
            //string [] names = new string[n];
            //for (int i = 0; i < names.Length; i++)
            //{
            //    names[i] = Console.ReadLine();
            //}


            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}



            //int n = int.Parse(Console.ReadLine());
            //int[] numbers = new int[n];
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    numbers[i] = i +1;
            //    Console.WriteLine(numbers[i]);
            //}

            string[] towns = { 
            "Sofiq",
            "Sliven",
            "Stara zagora",
            "Gorno nanadolnishte"
            };
            foreach (string town in towns)
            {
                Console.WriteLine(town);
            }
        }
    }
}
