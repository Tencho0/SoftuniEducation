using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isUsed = false;
            bool isValidPassword = ReturnIsPasswordValid(password, isUsed);
            if (isValidPassword)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool PrintIsItHaveMinDitisCount(string password, bool isUsed)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 48 && password[i] <= 57))
                {
                    counter++;
                }
            }
            if (counter < 2)
            {
                return true;
            }
            else return false;
        }

        private static bool PrintIsDigitsValid(string password, bool isUsed)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!((password[i] >= 48 && password[i] <= 57) || (password[i] >= 97 && password[i] <= 122) || (password[i] >= 65 && password[i] <= 90)))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool PrintIsLettersValid(string password, bool isUsed)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return true;
            }
            return false;
        }
        private static bool ReturnIsPasswordValid(string password, bool isUsed)
        {
            bool isValidPassword = true;
            if (PrintIsLettersValid(password, isUsed))
            {
                isValidPassword = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (PrintIsDigitsValid(password, isUsed))
            {
                isValidPassword = false;
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (PrintIsItHaveMinDitisCount(password, isUsed))
            {
                isValidPassword = false;
                Console.WriteLine("Password must have at least 2 digits");
            }
            return isValidPassword;
        }
    }
}
