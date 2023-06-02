namespace T05SchoolTeams
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var girlsComb = new string[3];
            var girlsCombs = new List<string[]>();
            GenCombs(0, 0, girls, girlsComb, girlsCombs);

            var boys = Console.ReadLine().Split(", ");
            var boysComb = new string[2];
            var boysCombs = new List<string[]>();
            GenCombs(0, 0, boys, boysComb, boysCombs);

            PrintFinalCombs(girlsCombs, boysCombs);
        }

        private static void PrintFinalCombs(List<string[]> girlsCombs, List<string[]> boysCombs)
        {
            foreach (var girlsComb in girlsCombs)
            {
                foreach (var boysComb in boysCombs)
                {
                    Console.WriteLine($"{string.Join(", ", girlsComb)}, {string.Join(", ", boysComb)}");
                }
            }
        }

        private static void GenCombs(int index, int start, string[] elements, string[] comb, List<string[]> combs)
        {
            if (index >= comb.Length)
            {
                combs.Add(comb.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                comb[index] = elements[i];
                GenCombs(index + 1, i + 1, elements, comb, combs);
            }
        }
    }
}