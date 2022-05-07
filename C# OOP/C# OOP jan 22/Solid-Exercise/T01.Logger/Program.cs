using System;
using System.Collections.Generic;

namespace T01.Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IAppender> appenders = new List<IAppender>();

            int appendersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string appenderType = appenderData[0];
                string layoutType = appenderData[1];

                ReportLevel reportLevel = appenderData.Length == 3
                    ? Enum.Parse<ReportLevel>(appenderData[2], true)
                    : ReportLevel.Info;
                ILayout layout = LayoutFactory.CreateLayout(layoutType);
                IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders.ToArray());

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] messageInfo = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(messageInfo[0], true);
                // DateTime dateTime = DateTime.Parse(messageInfo[1]);
                string message = messageInfo[2];

                switch (reportLevel)
                {
                    case ReportLevel.Fatal:
                        logger.Fatal(message);
                        break;
                    case ReportLevel.Critical:
                        logger.Critical(message);
                        break;
                    case ReportLevel.Error:
                        logger.Error(message);
                        break;
                    case ReportLevel.Warning:
                        logger.Warning(message);
                        break;
                    default:
                        logger.Info(message);
                        break;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Logger info");

            foreach (var appender in logger.Appenders)
            {
                Console.WriteLine(appender);
            }



            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevel.Error;

            //var logger = new Logger(consoleAppender);

            //logger.Info("Everything seems fine");
            //logger.Warning("Warning: ping is too high - disconnect imminent");
            //logger.Error("Error parsing request");
            //logger.Fatal("mscorlib.dll does not respond");
            //logger.Critical("No connection string found in App.config");


            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //ILogger logger = new Logger(consoleAppender);
            //
            //logger.Error("Error parsing JSON.");
            //logger.Info("User Pesho successfully registered.");

            // var simpleLayout = new SimpleLayout();
            // var consoleAppender = new ConsoleAppender(simpleLayout);
            //
            // var file = new LogFile();
            // var fileAppender = new FileAppender(simpleLayout, file);
            //
            // var logger = new Logger(consoleAppender, fileAppender);
            // logger.Error("Error parsing JSON.");
            // logger.Info("User Pesho successfully registered.");


            // var xmlLayout = new XmlLayout();
            // var consoleAppender = new ConsoleAppender(xmlLayout);
            // var logger = new Logger(consoleAppender);
            //
            // logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            // logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");


            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);

            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout, file);

            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
