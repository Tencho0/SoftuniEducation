using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double expenses = 0;
            int timesOfBrokenMouse = 0;
            int timesOfBrokenHeadset = 0;
            int timesOfBrokenkeyboard = 0;
            int timesOfBrokenDisplay = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0 && i % 3 == 0) 
                {
                    timesOfBrokenHeadset++;
                    timesOfBrokenMouse++;
                    timesOfBrokenkeyboard++;
                }
                else if (i % 2 == 0)
                {
                    timesOfBrokenHeadset++;
                }
                else if (i % 3 == 0)
                {
                    timesOfBrokenMouse++;
                }
            }

            timesOfBrokenDisplay = timesOfBrokenkeyboard / 2;

            expenses = (timesOfBrokenHeadset * headsetPrice) + (timesOfBrokenMouse * mousePrice) + (timesOfBrokenkeyboard * keyboardPrice) + (timesOfBrokenDisplay * displayPrice);

            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
