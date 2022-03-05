using System;

namespace T01.SumofGCPandLCM2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());
            long m = int.Parse(Console.ReadLine());
            long GPC = FindGPC(n,m);
            long nok = findLCM(m, n);
            Console.WriteLine(nok + GPC);
        }
        static long FindGPC(long n, long m)
        {
            if (m == 0)
            {
                return n;
            }
            else
            {
                return FindGPC(m, n % m);
            }
        }
        public static long findLCM(long a, long b)
        {
            long num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (long i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }
    }
}
