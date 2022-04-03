using System;
using System.Text.RegularExpressions;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Complete")
            {
                string[] givenCmd = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                if (action != "Make" && action != "Insert" && action != "Replace" && action != "Validation")
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (action == "Make")
                {
                    string upperOrLower = givenCmd[1];
                    int index = int.Parse(givenCmd[2]);

                        string letter = password.Substring(index, 1);
                        password = password.Remove(index, 1);

                        if (upperOrLower == "Upper")
                        {
                            password = password.Insert(index, (letter.ToUpper()));
                        }
                        else if (upperOrLower == "Lower")
                        {
                            password = password.Insert(index, (letter.ToLower()));
                        }
                        Console.WriteLine(password);
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(givenCmd[1]);
                    string givenChar = givenCmd[2];

                    if (IsIndexValid(index, password))
                    {
                        password = password.Insert(index, givenChar);
                        Console.WriteLine(password);
                    }
                }
                else if (action == "Replace")
                {
                    char givenChar = char.Parse(givenCmd[1]);
                    int givenValue = int.Parse(givenCmd[2]);
                    if (password.Contains(givenChar))
                    {
                        int oldChar = givenChar;
                        char newSymbol = (char)(oldChar + givenValue);
                        if (newSymbol >= 0)
                        {
                            password = password.Replace(givenChar, newSymbol);
                        }
                            Console.WriteLine(password);
                    }
                }
                else if (action == "Validation")
                {

                    int digits = 0;
                    int upperLetters = 0;
                    int lowerLetters = 0;
                    int underscoreCount = 0;
                    int symbols = 0;

                    foreach (char letter in password)
                    {
                        if (char.IsDigit(letter))
                        {
                            digits++;
                        }
                        else if (char.IsUpper(letter))
                        {
                            upperLetters++;
                        }
                        else if (char.IsLower(letter))
                        {
                            lowerLetters++;
                        }
                        else if( letter == '_')
                        {
                            underscoreCount++;
                        }
                        else
                        {
                            symbols++;
                        }
                    }

                    if (password.Length < 8)
                    {
                        Console.WriteLine($"Password must be at least 8 characters long!");
                    }
                    if (symbols > 0)
                    {
                        Console.WriteLine($"Password must consist only of letters, digits and _!");
                    }
                    if (upperLetters == 0)
                    {
                        Console.WriteLine($"Password must consist at least one uppercase letter!");
                    }
                    if (lowerLetters == 0)
                    {
                        Console.WriteLine($"Password must consist at least one lowercase letter!");
                    }
                    if (digits == 0)
                    {
                        Console.WriteLine($"Password must consist at least one digit!");
                    }
                    //string pattern = @"[A-Za-z_0-9]+";
                    //string uppLetternPattern = @"[A-Z]";
                    //string lowwerLetterPattern = @"[a-z]";
                    //string digitsPattern = @"[0-9]";

                    //Match match = Regex.Match(password, pattern);
                    //MatchCollection digits = Regex.Matches(password, digitsPattern);
                    //MatchCollection upperLetters = Regex.Matches(password, uppLetternPattern);
                    //MatchCollection lowerLetters = Regex.Matches(password, lowwerLetterPattern);

                    //if (password.Length < 8)
                    //{
                    //    Console.WriteLine($"Password must be at least 8 characters long!");
                    //}
                    //if (!(match.Success))
                    //{
                    //    Console.WriteLine($"Password must consist only of letters, digits and _!");
                    //}
                    //if (upperLetters.Count == 0)
                    //{
                    //    Console.WriteLine($"Password must consist at least one uppercase letter!");
                    //}
                    //if (lowerLetters.Count == 0)
                    //{
                    //    Console.WriteLine($"Password must consist at least one lowercase letter!");
                    //}
                    //if (digits.Count == 0)
                    //{
                    //    Console.WriteLine($"Password must consist at least one digit!");
                    //}
                }
                command = Console.ReadLine();
            }
        }

        private static bool IsIndexValid(int index, string password)
        {
            return index >= 0 && index < password.Length;
        }
    }
}
