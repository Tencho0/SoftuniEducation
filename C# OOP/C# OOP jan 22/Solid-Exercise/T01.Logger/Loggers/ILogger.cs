namespace T01.Logger
{
    public interface ILogger
    {
        IAppender[] Appenders { get; }
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Critical(string message);
        void Fatal(string message);
    }
}
