using System;
namespace T02.EnterNumbers
{
    class Program
    {
        static void Main()
        {
            int start = 1;
            int end = 100;
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    array[i] = ReadNumber(start, end);

                    if (array[i] <= start || array[i] > end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (FormatException exception)
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                    continue;
                }
                catch (ArgumentOutOfRangeException exception2)
                {
                    Console.WriteLine($"Your number is not in range {start} - {end}!");
                    i--;
                    continue;
                }

                start = array[i];
            }

            Console.WriteLine(string.Join(", ", array));
        }
        public static int ReadNumber(int start, int end)
        {
            string number = Console.ReadLine();
            int num;
            if (!int.TryParse(number, out num))
            {
                throw new FormatException();
            }
            return num;
        }
    }
}