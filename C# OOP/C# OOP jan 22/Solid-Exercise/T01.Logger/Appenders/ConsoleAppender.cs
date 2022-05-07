namespace T01.Logger
{
    using System;
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            this.AppendedMessages++;
            string output = string.Format(this.Layout.Format, dateTime, reportLevel, message);
            Console.WriteLine(output);
        }
    }
}
