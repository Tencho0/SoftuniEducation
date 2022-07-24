namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using CommandPattern.IO.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter cmdInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ICommandInterpreter cmdInterpreter, IReader reader, IWriter writer)
        {
            this.cmdInterpreter = cmdInterpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();

                string result = this.cmdInterpreter.Read(input);
                this.writer.WriteLine(result);
                this.writer.ResetStyle();
            }
        }
    }
}
