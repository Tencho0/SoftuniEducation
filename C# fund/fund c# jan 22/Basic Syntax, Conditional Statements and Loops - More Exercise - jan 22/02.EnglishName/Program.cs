using System;

namespace _02.EnglishName
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(LastDigitAsString(number));
        }

         static string  LastDigitAsString(int number)
        {
            int lastDigit = number % 10;
            string lastDigitAlsString = string.Empty;
            if (lastDigit == 1)
            {
                lastDigitAlsString = "one";
            }
            else if (lastDigit == 2)
            {
                lastDigitAlsString = "two";
            }
            else if (lastDigit == 3)
            {
                lastDigitAlsString = "three";
            }
            else if (lastDigit == 4)
            {
                lastDigitAlsString = "four";
            }
            else if (lastDigit == 5)
            {
                lastDigitAlsString = "five";
            }
            else if (lastDigit == 6)
            {
                lastDigitAlsString = "six";
            }
            else if (lastDigit == 7)
            {
                lastDigitAlsString = "seven";
            }
            else if (lastDigit == 8)
            {
                lastDigitAlsString = "eight";
            }
            else if (lastDigit == 9)
            {
                lastDigitAlsString = "nine";
            }
            else if (lastDigit == 0)
            {
                lastDigitAlsString = "zero";
            }
            return lastDigitAlsString;
        }
    }
}
