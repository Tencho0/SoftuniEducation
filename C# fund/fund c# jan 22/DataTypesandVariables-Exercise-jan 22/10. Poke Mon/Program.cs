using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int targets = 0;
            double originNvalue = n * 0.5;

            while (n >= m)
            {
                n -= m;
                targets++;
                if (n == originNvalue)
                {
                    if (y != 0)
                    {
                        n /= y;
                    }
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(targets);
        }
    }
}
