using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string parentheses = Console.ReadLine(); // Change the value of parentheses to adjust the input

        int length = LengthOfValidCombination(parentheses);

        //Console.WriteLine($"The length of the longest valid combination of parentheses in '{parentheses}' is: {length}");
        Console.WriteLine(length);
    }

    static int LengthOfValidCombination(string parentheses)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(-1);
        int length = 0;

        for (int i = 0; i < parentheses.Length; i++)
        {
            if (parentheses[i] == '(')
            {
                stack.Push(i);
            }
            else
            {
                stack.Pop();

                if (stack.Count == 0)
                {
                    stack.Push(i);
                }
                else
                {
                    int currentLength = i - stack.Peek();

                    if (currentLength > length)
                    {
                        length = currentLength;
                    }
                }
            }
        }

        return length;
    }
}