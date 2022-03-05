using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstElement = Console.ReadLine().Split();
            string[] secondElement = Console.ReadLine().Split();
            foreach (string secondArray in secondElement)
            {
                foreach (var firstArray in firstElement)
                {
                    if (firstArray == secondArray)
                    {
                        Console.Write(firstArray + " ");
                    }
                }
            }
        }
    }
}
