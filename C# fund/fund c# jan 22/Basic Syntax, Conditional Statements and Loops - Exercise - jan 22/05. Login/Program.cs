using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = string.Empty;

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password += userName[i];
            }

            int wrongPasswordCounter = 0;
            string givenPassword = Console.ReadLine();
            while (givenPassword != password)
            {
                wrongPasswordCounter++;
                if (wrongPasswordCounter == 4)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                givenPassword = Console.ReadLine();
            }

            if (givenPassword == password)
            {
                Console.WriteLine($"User {userName} logged in.");
            }
        }
    }
}
