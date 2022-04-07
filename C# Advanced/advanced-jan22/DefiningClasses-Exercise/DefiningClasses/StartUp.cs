using System;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            Console.WriteLine(DateModifier.Difference(firstDate, secondDate));
        }
    }
}
