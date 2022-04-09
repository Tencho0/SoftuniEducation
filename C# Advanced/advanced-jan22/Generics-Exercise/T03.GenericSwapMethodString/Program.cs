using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Box<string> inputBox = new Box<string>(input);
                boxes.Add(inputBox);
            }
            ChangeIndices(boxes);

        }

        private static void ChangeIndices(List<Box<string>> boxes)
        {
            int[] changeIndices = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            var tempBox = boxes[changeIndices[0]];
            boxes[changeIndices[0]] = boxes[changeIndices[1]];
            boxes[changeIndices[1]] = tempBox;
            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
