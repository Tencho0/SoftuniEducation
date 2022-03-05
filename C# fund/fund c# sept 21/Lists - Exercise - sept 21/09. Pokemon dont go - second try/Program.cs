using System;
using System.Linq;

namespace _09._Pokemon_dont_go___second_try
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            int currValue = 0;
            int result = 0;
            int index = -1;
            while (sequence.Count != 0)
            {
                index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    currValue = sequence[0];
                    result += currValue;
                    sequence[0] = sequence[sequence.Count - 1];
                }
                else if (index >= sequence.Count)
                {
                    currValue = sequence[sequence.Count - 1];
                    result += currValue;
                    sequence[sequence.Count -1] = sequence[0];
                }
                else
                {
                    currValue = sequence[index];
                    result += currValue;
                    sequence.RemoveAt(index);
                }

                for (int i = 0; i < sequence.Count; i++)
                {
                    if (currValue >= sequence[i])
                    {
                        sequence[i] += currValue;
                    }
                    else
                    {
                        sequence[i] -= currValue;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
