using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace problem_1_password_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5323;
            foreach (var item in a)
            {

            }

            string something = "Hello word";
            Console.WriteLine(something.Substring(3,4));


            Console.WriteLine(100f == 100d);
            return;
            for (int i = 10; i > 3; i-=2)
            {
                Console.WriteLine($"{i}");
            }
            return;

            Regex regex = new Regex(@"[A-z_]{8,}");

            string word = Console.ReadLine();
            List<char> charArr = word.ToList();

            while (true)
            {
                int upperCount = 0;
                int lowerCount = 0;
                int digitCount = 0;
                string n = Console.ReadLine();

                if (n == "Complete")
                {
                    break;
                }
                string[] split = n.Split();

                if (split[0] == "Make")
                {
                    if (split[1] == "Upper")
                    {
                        int index = int.Parse(split[2]);
                        for (int i = 0; i < index; i++)
                        {
                            if (i == index - 1)
                            {
                                charArr[i + 1] = char.ToUpper(charArr[i + 1]);
                            }
                        }
                    }
                    else if (split[1] == "Lower")
                    {
                        int index = int.Parse(split[2]);
                        for (int i = 0; i < index; i++)
                        {
                            if (i == index - 1)
                            {
                                charArr[i + 1] = char.ToLower(charArr[i + 1]);
                            }
                        }
                    }
                    Console.WriteLine(string.Join("", charArr));

                }
                else if (split[0] == "Insert")
                {
                    int index = int.Parse(split[1]);
                    if (index < 0 || index > charArr.Count)
                    {
                        continue;
                    }
                    else
                    {
                        char character = char.Parse(split[2]);
                        charArr.Insert(index, character);
                        Console.WriteLine(string.Join("", charArr));
                    }

                }
                else if (split[0] == "Replace")
                {
                    char character = char.Parse(split[1]);
                    if (charArr.Contains(character))
                    {

                        int asciiValue = (int)character;
                        int replacement = int.Parse(split[2]);
                        int sum = asciiValue + replacement;
                        string transform = string.Join("", charArr);
                        transform = transform.Replace(character, (char)sum);
                        charArr = transform.ToList();
                        Console.WriteLine(string.Join("", charArr));
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (split[0] == "Validation")
                {

                    if (charArr.Count < 8)
                    {
                        Console.WriteLine($"Password must be at least 8 characters long!");
                    }

                    foreach (var item in charArr)
                    {
                        if (char.IsLetterOrDigit(item))
                        {

                        }
                        else if (item == '_')
                        {

                        }
                        else
                        {
                            Console.WriteLine($"Password must consist only of letters, digits and _!");
                        }

                        if (char.IsUpper(item))
                        {
                            upperCount++;
                        }
                        else if (char.IsLower(item))
                        {
                            lowerCount++;
                        }
                        else if (char.IsDigit(item))
                        {
                            digitCount++;
                        }
                    }

                    if (upperCount == 0)
                    {
                        Console.WriteLine("Password must consist at least one uppercase letter!");
                    }
                    if (lowerCount == 0)
                    {
                        Console.WriteLine("Password must consist at least one lowercase letter!");

                    }
                    if (digitCount == 0)
                    {
                        Console.WriteLine("Password must consist at least one digit!");

                    }
                }

            }


        }
    }
}
