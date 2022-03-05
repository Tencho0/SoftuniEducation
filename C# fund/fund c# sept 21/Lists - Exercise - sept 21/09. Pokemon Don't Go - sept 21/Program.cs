using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._Pokemon_Don_t_Go___sept_21
{
    class Program
    {

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            int index = -1;
            while (numbers.Count > 0)
            {
                index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    index = 0;
                    numbers[0] = numbers[numbers.Count - 1];
                }
                else if (index > numbers.Count - 1)
                {
                    numbers[numbers.Count - 1] = numbers[0];
                    index = numbers.Count - 1;
                }
                sum += numbers[index];
                int numAtCurrIndex = numbers[index];
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numAtCurrIndex >= numbers[i])
                    {
                        numbers[i] += numAtCurrIndex;
                    }
                    else
                    {
                        numbers[i] -= numAtCurrIndex;
                    }

                }
                numbers.RemoveAt(index);
            }
            Console.WriteLine(sum);
        }
    }
}
