using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstData = Console.ReadLine();
            string secondData = Console.ReadLine();
            int result = DateModifier.Difference(firstData, secondData);
            Console.WriteLine(result);
        }
    }
}
