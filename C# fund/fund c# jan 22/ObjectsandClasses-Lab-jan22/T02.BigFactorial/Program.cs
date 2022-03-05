﻿using System;
using System.Numerics;

namespace T02.BigFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger sum = 1;
            for (int i = 2; i <= n; i++)
            {
                sum *= i;
            }
            Console.WriteLine(sum);
        }
    }
}
