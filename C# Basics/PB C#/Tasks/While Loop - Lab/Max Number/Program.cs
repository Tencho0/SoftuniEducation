﻿using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int theNum = int.MinValue;
            while (text != "Stop")
            {
                int num = int.Parse(text);
                if (num > theNum)
                {
                    theNum = num;
                }
                text = Console.ReadLine();
            }
            Console.WriteLine(theNum);
        }
    }
}
