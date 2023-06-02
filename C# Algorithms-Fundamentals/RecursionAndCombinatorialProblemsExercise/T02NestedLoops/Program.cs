namespace T02NestedLoops
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        private static int[] elements;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            elements = new int[n];
            GenVectors(0);

            //int[] initialIteration = new int[0];
            //NestedLoops(n, initialIteration);
        }

        static void GenVectors(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[index] = i;
                GenVectors(index + 1);
            }
        }

        static void NestedLoops(int n, int[] currentIteration)
        {
            if (currentIteration.Length == n)
            {
                Console.WriteLine(string.Join(" ", currentIteration));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                int[] newIteration = new int[currentIteration.Length + 1];
                Array.Copy(currentIteration, newIteration, currentIteration.Length);
                newIteration[currentIteration.Length] = i;

                NestedLoops(n, newIteration);
            }
        }
    }

}