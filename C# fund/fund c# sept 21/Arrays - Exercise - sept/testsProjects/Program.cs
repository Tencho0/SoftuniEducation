using System;
using System.Linq;

namespace testsProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 0;
            int winningCounter = 0;
            string number = string.Empty;
            for (int i = 0; i < sequence.Length -1; i++)
            {
                if (sequence[i] == sequence[i+1])
                {
                    counter++;
                    if (counter > winningCounter)
                    {
                        winningCounter = counter;
                        number = sequence[i].ToString();
                    }
                }
                else
                {
                    counter = 0;
                }
            }
            for (int i = 0; i <= winningCounter; i++)
            {
                Console.Write(number + " ");
            }
        }
    }
}
