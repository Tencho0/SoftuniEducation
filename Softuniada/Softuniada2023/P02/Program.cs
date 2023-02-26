using System;

class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());

        DrawRocket(size);

        static void DrawRocket(int size)
        {
            Console.Write(new string('_', (size + 4) / 2));
            Console.Write('^');
            Console.WriteLine(new string('_', (size + 4) / 2));

            for (int i = 1; i < size; i++)
            {
                if (i == 1)
                {
                    Console.Write(new string('_', (size + 5 - 3) / 2));
                    Console.Write('/');
                    Console.Write(new string('|', i));
                    Console.Write('\\');
                    Console.WriteLine(new string('_', (size + 5 - 3) / 2));
                }
                else
                {
                    Console.Write(new string('_', size / i));
                    Console.Write('/');
                    Console.Write(new string('.', i - 2));
                    Console.Write(new string('|', 3));
                    Console.Write(new string('.', i - 2));
                    Console.Write('\\');
                    Console.WriteLine(new string('_', size / i));
                }
            }

            Console.Write("_/");
            Console.Write(new string('.', (size + 1 - 3) / 2));
            Console.Write(new string('|', 3));
            Console.Write(new string('.', (size + 1 - 3) / 2));
            Console.WriteLine("\\_");

            for (int i = 0; i < size; i++)
            {
                // Draw the middle part of the rocket
                Console.Write(new string('_', (size + 2) / 2));
                Console.Write(new string('|', 3));
                Console.WriteLine(new string('_', (size + 2) / 2));
            }

            Console.Write(new string('_', (size + 2) / 2));
            Console.Write(new string('~', 3));
            Console.WriteLine(new string('_', (size + 2) / 2));

            //for (int i = size / 2; i < size - 1; i++)
            //for (int i = size; i >= size / 2 + 1; i--)
            for (int i = 0; i < size / 2; i++)
            {
                Console.Write(new string('_', size / 2 - i));
                Console.Write(new string('/', 2));
                //Console.Write(new string('.', i - 2));
                Console.Write(new string('.', i));
                Console.Write(new string('!', 1));
                Console.Write(new string('.', i));
                // Console.Write(new string('.', i - 2));
                Console.Write(new string('\\', 2));
                Console.WriteLine(new string('_', size / 2 - i));
            }
        }

        //static void DrawRocket(int N)
        //{
        //    // Draw the top cone
        //    for (int i = 1; i <= N; i++)
        //    {
        //        for (int j = 1; j <= 2 * N - 1; j++)
        //        {
        //            if (j >= N - i + 1 && j <= N + i - 1)
        //            {
        //                Console.Write("*");
        //            }
        //            else
        //            {
        //                Console.Write("_");
        //            }
        //        }
        //        Console.WriteLine();
        //    }

        //    // Draw the top separator
        //    for (int i = 1; i <= N / 2; i++)
        //    {
        //        Console.Write(new string('.', N - i));
        //        Console.Write(new string('*', 2 * i));
        //        Console.Write(new string('.', N - i));
        //        Console.WriteLine();
        //    }

        //    // Draw the bottom separator
        //    for (int i = N / 2; i >= 1; i--)
        //    {
        //        Console.Write(new string('.', N - i));
        //        Console.Write(new string('*', 2 * i));
        //        Console.Write(new string('.', N - i));
        //        Console.WriteLine();
        //    }

        //    // Draw the bottom cone
        //    for (int i = N; i >= 1; i--)
        //    {
        //        for (int j = 1; j <= 2 * N - 1; j++)
        //        {
        //            if (j >= N - i + 1 && j <= N + i - 1)
        //            {
        //                Console.Write("*");
        //            }
        //            else
        //            {
        //                Console.Write(" ");
        //            }
        //        }
        //        Console.WriteLine();
        //    }

        //    // Draw the rocket base
        //    Console.Write(new string('-', 2 * N));
        //    Console.WriteLine();
        //    Console.Write(new string('\\', N));
        //    Console.Write(new string('/', N));
        //    Console.WriteLine();
        //    Console.Write(new string('-', 2 * N));
        //    Console.WriteLine();
        //}
    }
}


//namespace Rocket
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = int.Parse(Console.ReadLine());
//            for (int i = 0; i < n; i++)
//            {
//                Console.WriteLine(new string('_', (n * 2) - ((n / 2) + 1) - i) + '/' + new string(' ', i * 2) + '\\' + new string('_', (n * 2) - ((n / 2) + 1) - i));
//            }

//            for (int i = 0; i < n * 2; i++)
//            {
//                Console.WriteLine(new string('_', n / 2) + '|' + new string('\\', n * 2 - 2) + '|' + new string('_', n / 2));
//            }
//            for (int i = 0; i < n / 2; i++)
//            {
//                Console.WriteLine(new string('_', (n / 2) - i) + '/' + new string('*', (n * 2 - 2) + 2 * i) + '\\' + new string('_', (n / 2) - i));
//            }
//        }
//    }
//}

