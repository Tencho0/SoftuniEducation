using System;

namespace T03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split('\\');
            string[] lastElement = arr[arr.Length - 1].Split('.');
            string name = lastElement[0];
            string extension = lastElement[1];
            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
