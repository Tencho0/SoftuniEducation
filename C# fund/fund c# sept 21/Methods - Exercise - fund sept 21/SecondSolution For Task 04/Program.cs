using System;

namespace SecondSolution_For_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            if (!ValidatePasswordLength(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!ValidatePasswordText(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!ValidatePasswordDigit(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (ValidatePasswordDigit(password) && ValidatePasswordLength(password) && ValidatePasswordText(password))
            {
                Console.WriteLine("Password is valid");
            }
        }
        static bool ValidatePasswordLength(string text)
        {
            return text.Length >= 6 && text.Length <= 10;
        }
        static bool ValidatePasswordText(string text)
        {
            foreach (char character in text)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    return false;
                }
            }
            return true;
        }
        static bool ValidatePasswordDigit(string text)
        {
            int countDigit = 0;
            foreach (var character in text)
            {
                if (char.IsDigit(character))
                {
                    countDigit++;
                }
            }
            return countDigit >= 2;
        }
    }
}
