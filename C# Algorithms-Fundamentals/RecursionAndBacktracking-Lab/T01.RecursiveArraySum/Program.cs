namespace T01.RecursiveArraySum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(Sum(numbers, 0));
        }

        private static int Sum(int[] numbers, int index)
        {
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }

            return numbers[index] + Sum(numbers, index + 1);
        }
    }
}