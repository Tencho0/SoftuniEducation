using System;

namespace _01._Encrypt__Sort_and_Print_Array___sept_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            int repsOfNames = int.Parse(Console.ReadLine());
            string[] names = new string[repsOfNames];
            int[] asciiValues = new int[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = Console.ReadLine();
                int currValueForTheName = 0;
                foreach (char index in names[i])
                {
                    if (index == 'a' || index == 'e' || index == 'i' || index == 'o' || index == 'u' || index == 'A' || index == 'E' || index == 'I' || index == 'O' || index == 'U')
                    {

                        currValueForTheName += ((int)index * names[i].Length);
                    }
                    else
                    {
                        currValueForTheName += ((int)index / names[i].Length);
                    }
                }
                asciiValues[i] = currValueForTheName;
            }
            //Console.WriteLine(string.Join(" ", asciiValues));

            Array.Sort(asciiValues);
            for (int i = 0; i < asciiValues.Length; i++)
            {
                Console.WriteLine(asciiValues[i]);
            }
        }
    }
}
