using System;
using System.Numerics;
namespace _02._Big_Factorial___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Factorial calculator = new Factorial(n);
            Console.WriteLine(calculator.Calculated());
        }
    }
}
