namespace CommandPattern.Core.Commands
{
    using Contracts;
    using System;

    public class WarningCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            return $"{args[0]}";
        }
    }
}
