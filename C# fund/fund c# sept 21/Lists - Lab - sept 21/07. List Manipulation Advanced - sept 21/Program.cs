using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> originalList = new List<int>();
            bool isChanged = false;
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArr = command.Split();
                switch (commandArr[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(commandArr[1]));
                        isChanged = true;
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(commandArr[1]));
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(commandArr[1]));
                        isChanged = true;
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(commandArr[2]), int.Parse(commandArr[1]);
                        isChanged = true;
                        break;
                    case "Contains":
                        if (numbers.Contains(int.Parse(commandArr[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PritEven":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                Console.Write($"{numbers[i]} ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "PritOdd":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 != 0)
                            {
                                Console.Write($"{numbers[i]} ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "GetSum":
                        int sum = 0;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            sum += numbers[i];
                        }
                        Console.WriteLine(sum);
                        break;

                }
                command = Console.ReadLine();
            }
        }
    }
}
