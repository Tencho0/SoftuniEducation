using System;

namespace Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string theBestPlayer = "";
            int a = int.MinValue;
            int theBestPlayerGoals = 0;

            while (name != "END")
            {
                int goals = int.Parse(Console.ReadLine());
                if (goals > a)
                {
                    theBestPlayer = name;
                    a = goals;
                }
                if (a >= 10)
                {
                    break;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"{theBestPlayer} is the best player!");
            if (a >= 3)
            {
                Console.WriteLine($"He has scored {a} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {a} goals.");
            }
        }
    }
}
