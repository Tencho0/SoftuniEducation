using System;
using System.Linq;

namespace _09._2Pokemon_dont_go___sept_21___dktaks
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            int index;
            int currentValue;
            int result = 0;
            while (sequence.Count != 0)
            {
                index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    index = 0;
                    currentValue = sequence[0];
                    result += currentValue;
                    sequence[0] = sequence[sequence.Count - 1];
                }
                else if (index> sequence.Count -1)
                {
                    currentValue = sequence[sequence.Count - 1];
                    result += currentValue;
                    sequence[sequence.Count - 1] = sequence[0];
                }
                else
                {
                    currentValue = sequence[index];
                    result += currentValue;
                    sequence.RemoveAt(index);
                }
                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i] <= currentValue)
                    {
                        sequence[i] += currentValue;
                    }
                    else
                    {
                        sequence[i] -= currentValue;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
