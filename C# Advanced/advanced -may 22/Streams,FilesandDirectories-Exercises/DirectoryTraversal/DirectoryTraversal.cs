namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            Dictionary<string, List<FileInfo>> extensionsInfo = new Dictionary<string, List<FileInfo>>();
            StringBuilder sb = new StringBuilder();

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!extensionsInfo.ContainsKey(extension))
                {
                    extensionsInfo.Add(extension, new List<FileInfo>());
                }

                extensionsInfo[extension].Add(fileInfo);
            }
            
            foreach (var entry in extensionsInfo.OrderByDescending(entry => entry.Value.Count).ThenBy(entry => entry.Key))
            {
                string extension = entry.Key;
                sb.AppendLine(extension);  
                List<FileInfo> filesInfo = entry.Value;
                filesInfo.OrderByDescending(file => file.Length);

                foreach (FileInfo fileInfo in filesInfo)
                {
                    sb.AppendLine($"--{fileInfo.Name} - {fileInfo.Length / 1024:F3}kb");
                }
            }

            return sb.ToString().Trim();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string pathReport = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(pathReport, textContent);
        }
    }
}
