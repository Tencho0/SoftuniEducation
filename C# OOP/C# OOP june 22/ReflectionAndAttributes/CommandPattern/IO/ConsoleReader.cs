namespace CommandPattern.IO
{
    using CommandPattern.IO.Contracts;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
