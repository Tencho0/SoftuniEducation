using System;

namespace _01._Smallest_of_Three_Numbers___fund_sept_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(SmallestNumber(a, b, c));
        }
        static int SmallestNumber(int a, int b, int c)
        {

            return Math.Min(a, Math.Min(b, c));

            //int comparison1 = Math.Min(a, b);
            //int comparison2 = Math.Min(b, c);
            //if (comparison1 > comparison2)
            //{
            //    return comparison2;
            //}
            //else
            //{
            //    return comparison1;
            //}


            //int[] array = new int[3];
            //array[0] = a;
            //array[1] = b;
            //array[2] = c;
            //Array.Sort(array);
            //return array[0];
        }
    }
}
