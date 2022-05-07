namespace T01.Logger
{
    using System;
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout, ReportLevel reportlevel = ReportLevel.Info)
        {
            IAppender appender = type switch
            {
                "FileAppender" => new FileAppender(layout, new LogFile(), "../../../log.txt"),
                "ConsoleAppender" => new ConsoleAppender(layout),
                _ => throw new InvalidOperationException("Missing type!")
            };
            appender.ReportLevel = reportlevel;
            return appender;
        }
    }
}
