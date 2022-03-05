using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceOfElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 0;
            int winningCounter = 0;
            string number = string.Empty;

            for (int i = 0; i < sequenceOfElements.Length -1; i++)
            {
                if (sequenceOfElements[i] == sequenceOfElements[i +1])
                {
                    counter++;
                    if (counter> winningCounter)
                    {
                        winningCounter = counter;
                        number = sequenceOfElements[i].ToString();
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
