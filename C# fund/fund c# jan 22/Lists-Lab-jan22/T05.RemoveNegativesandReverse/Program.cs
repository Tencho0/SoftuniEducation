using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.RemoveNegativesandReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine().Split().Select(int.Parse).ToList();
            elements.RemoveAll(n => n < 0);
            //for (int i = 0; i < elements.Count; i++)
            //{
            //    int currNum = elements[i];
            //    if (currNum < 0)
            //    {
            //        elements.Remove(currNum);
            //        i--;
            //    }
            //}
            elements.Reverse();
            if (elements.Count != 0)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
