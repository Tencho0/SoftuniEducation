namespace ProgressTechInterview
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            Result.fizzBuzz(n);
        }
    }
    class Result
    {
        public static void fizzBuzz(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0 && i % 5 != 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 3 != 0 && i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 != 0 && i % 5 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

    }
}