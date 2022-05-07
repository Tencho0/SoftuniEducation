namespace T01.Logger
{
    using System.Text;
    using System.Linq;

    public class LogFile : ILogFile
    {
        private readonly StringBuilder stringBuilder;
        public LogFile() => stringBuilder = new StringBuilder();
        public int Size => this.stringBuilder
            .ToString()
            .Where(char.IsLetter)
            .Sum(x => x);

        public void Write(string message) => this.stringBuilder.Append(message);
    }
}
