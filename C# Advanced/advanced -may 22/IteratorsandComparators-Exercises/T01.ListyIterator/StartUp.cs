using System;
using System.Linq;

namespace T01.ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            ListyIterator<string> listy = null;
            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Create")
                {
                    listy = new ListyIterator<string>(tokens.Skip(1).ToArray());
                }
                else if (tokens[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (tokens[0] == "Print")
                {
                    listy.Print();
                }
                else if (tokens[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
            }
        }
    }
}
