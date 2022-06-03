using System;

namespace T05.DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            Console.WriteLine(DateModifier.Difference(firstDate, secondDate));
        }
    }
}
