using System;
using System.IO;

namespace T07.FolderSize
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class FolderSize
    {
        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;
            DirectoryInfo dir = new DirectoryInfo("../../../TestFolder");
            FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo info in infos)
            {
                sum += info.Length;
            }
            sum = sum / 1024 / 1025;
            File.WriteAllText("../../../output.txt", sum.ToString());
        }
    }

}
