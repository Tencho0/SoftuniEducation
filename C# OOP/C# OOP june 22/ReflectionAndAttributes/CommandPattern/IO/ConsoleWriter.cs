namespace CommandPattern.IO
{
    using CommandPattern.IO.Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void ResetStyle()
        {
            Console.ResetColor();
        }

        public void Write(string givenValue)
        {
            Console.Write(givenValue);
        }

        public void WriteLine(string givenValue)
        {
            Console.WriteLine(givenValue);
        }
    }
}
