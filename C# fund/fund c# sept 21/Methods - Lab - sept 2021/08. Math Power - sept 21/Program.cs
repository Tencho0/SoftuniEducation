using System;

namespace _08._Math_Power___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double result = FunkResult(a, b);
            Console.WriteLine(result);
            //double result = Result(a, b);
            //Console.WriteLine(result);
        }
        static double FunkResult(double a, double b)
        {
            double finalResult = Math.Pow(a, b);
            return finalResult;
        }
        //static double Result (double a, double b)
        //{
        //    double finalResult = a;
        //    for (int i = 0; i < b -1; i++)
        //    {
        //        finalResult *= a;
        //    }
        //    return finalResult;
        //}
    }
}
