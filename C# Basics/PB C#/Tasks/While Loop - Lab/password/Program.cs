using System;

namespace password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string passwordInput = Console.ReadLine();
            while (passwordInput !=password)
            {
                passwordInput = Console.ReadLine();
            }
                Console.WriteLine($"Welcome {username}!");
        }
    }
}
