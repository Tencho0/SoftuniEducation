using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> inputBox = new Box<int>(input);
                boxes.Add(inputBox);
            }
            ChangeIndices(boxes);

        }

        private static void ChangeIndices(List<Box<int>> boxes)
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
