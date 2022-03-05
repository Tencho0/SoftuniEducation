using System;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int time1 = int.Parse(Console.ReadLine());
            int time2 = int.Parse(Console.ReadLine());
            int time3 = int.Parse(Console.ReadLine());

            int totalSeconds = time1 + time2 + time3;
            int minutes = 0;
            int seconds = 0;

            if (totalSeconds >= 120)
            {
                minutes = 2;
                seconds = totalSeconds - 120;
            }
            else if (totalSeconds >=60)
            {
                minutes = 1;
                seconds = totalSeconds - 60;
            }
            else
            {
                seconds = totalSeconds;
            }

            Console.WriteLine($"{minutes}:{seconds:d2}");
        }
    }
}
