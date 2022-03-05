using System;

namespace _01.Encrypt_SortandPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int reps = int.Parse(Console.ReadLine());
            int[] values = new int[reps];
            for (int i = 0; i < reps; i++)
            {
                string word = Console.ReadLine();
                int wordLength = word.Length;
                int sum = 0;
                for (int j = 0; j < wordLength; j++)
                {
                    char index = word[j];
                    if (index == 'a' || index == 'e' || index == 'i' || index == 'o' || index == 'u' || index == 'A' || index == 'E' || index == 'I' || index == 'O' || index == 'U')
                    {
                        sum += (int)index * wordLength;
                    }
                    else
                    {
                        sum += (int)index / wordLength;
                    }
                }values[i] = sum;
            }
            Array.Sort(values);
            Console.WriteLine(string.Join("\n", values));
        }
    }
}
