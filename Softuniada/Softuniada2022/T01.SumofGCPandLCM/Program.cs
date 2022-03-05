using System;
using System.Collections.Generic;

namespace T01.SumofGCPandLCM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());
            long m = int.Parse(Console.ReadLine());
            List<long> firstGCP = new List<long>();
            List<long> secondGCP = new List<long>();

            for (long i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    firstGCP.Add(i);
                }
            }

            for (long i = 1; i <= m; i++)
            {
                if (m % i == 0)
                {
                    secondGCP.Add(i);
                }
            }

            long GPC = 0;
            long smallerCount = Math.Min(firstGCP.Count, secondGCP.Count);
            GPC = FindGPC(firstGCP, secondGCP);
            long nok = findLCM(m, n);
            Console.WriteLine(nok + GPC);
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
        static long FindGPC(List<long> firstGCP, List<long> secondGCP)
        {
            for (int i = firstGCP.Count - 1; i >= 0; i--)
            {
                for (int j = secondGCP.Count - 1; j >= 0; j--)
                {
                    if (firstGCP[i] == secondGCP[j] && firstGCP[i] != 1)
                    {
                        return firstGCP[i];
                    }
                }
            }
            return -1;
        }
    }
}
