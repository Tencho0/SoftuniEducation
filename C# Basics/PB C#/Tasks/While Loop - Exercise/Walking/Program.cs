using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int GOALSTEPS = 10000;
            int totalSteps = 0;

            while (totalSteps < GOALSTEPS)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    int stepsLeft = int.Parse(Console.ReadLine());
                    totalSteps += stepsLeft;
                    break;
                }
                int currentSteps = int.Parse(input);
                totalSteps += currentSteps;
            }
            if (totalSteps >= GOALSTEPS)
            {
                Console.WriteLine("Goal reached! Good job!");
                int stepsOverGoal = totalSteps - GOALSTEPS;
                Console.WriteLine($"{stepsOverGoal} steps over the goal!");
            }
            else
            {
                int difference = GOALSTEPS - totalSteps;
                Console.WriteLine($"{difference} more steps to reach goal.");
            }
        }
    }
}
