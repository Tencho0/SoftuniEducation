using System;

namespace T01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = int.Parse(Console.ReadLine());
                if (a < 0)
                {
                    throw new Exception("Invalid number.");
                }
                Console.WriteLine(Math.Sqrt(a));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
