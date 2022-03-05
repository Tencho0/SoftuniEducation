using System;

namespace _04._Password_Validator___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isValidChar = RuleForCharacters(password);
            bool isValidDigits = RuleForDigits(password);
            bool isValidLength = RulesForLength(password);

            if (isValidLength == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (isValidChar == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (isValidDigits == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isValidChar && isValidDigits && isValidLength)
            {
                Console.WriteLine("Password is valid");
            }
        }
        static bool RulesForLength(string password)
        {
            bool isValid = true;
            if (password.Length < 6 || password.Length > 10)
            {
                isValid = false;
            }
            return isValid;
        }
        static bool RuleForDigits(string password)
        {
            int count = 0;
            bool isValid = true;
            foreach (var digits in password)
            {
                if ("1234567890".Contains(digits))
                {
                    count++;
                }
            }
            if (count < 2)
            {
                isValid = false;
            }
            return isValid;
        }
        static bool RuleForCharacters(string password)
        {
            int count = 0;
            bool isValid = true;
            foreach (char digits in password)
            {
                if ((digits >= 48 && digits <= 57) || (digits >= 65 && digits <= 90) || (digits >= 97 && digits <= 122))
                {
                    isValid = true;
                }
                else
                {
                    count++;
                }
            }
            if (count > 0)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
