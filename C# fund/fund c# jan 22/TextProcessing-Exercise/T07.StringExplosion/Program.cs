using System;

namespace T07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (strength > 0 && input[i] != '>')
                {
                    input = input.Remove(i, 1);
                    strength--;
                    i--;
                }
                else if (input[i] == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                }
            }
            Console.WriteLine(input);
        }
    }
}
