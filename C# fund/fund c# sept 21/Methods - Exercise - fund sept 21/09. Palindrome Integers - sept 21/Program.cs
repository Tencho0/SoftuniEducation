using System;

namespace _09._Palindrome_Integers___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                Console.WriteLine(PalindromeNum(input));
                input = Console.ReadLine();
            }
        }
        static bool PalindromeNum(string input)
        {
            int digit = int.Parse(input);
            if (digit < 10)
            {
                return true;
            }
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] == input[input.Length - 1 - i])
                {
                    return true;
                }
                else
                {
                    break;
                }
            }
                    return false;
        }
    }
}
