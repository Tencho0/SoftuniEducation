using System;

namespace T01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new Exception();
                }
                Console.WriteLine(Math.Sqrt(n));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
