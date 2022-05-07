namespace T01.Logger
{
    using System;
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        void Append(DateTime dateTime, ReportLevel reportLevel, string message);
    }
}
