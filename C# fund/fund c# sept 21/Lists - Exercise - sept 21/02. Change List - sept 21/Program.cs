using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List___sept_21
{
    class Program
    {
        public static object Lis { get; private set; }

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArr = command.Split();
                if (commandArr[0] == "Delete")
                {
                    int addNum = int.Parse(commandArr[1]);
                    numbers.RemoveAll(el => el == addNum);
                    //for (int i = 0; i < numbers.Count; i++)
                    //{
                    //    numbers.Remove(addNum);
                    //}
                }
                else
                {
                    int addNum = int.Parse(commandArr[1]);
                    int possition = int.Parse(commandArr[2]);
                    numbers.Insert(possition, addNum);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
