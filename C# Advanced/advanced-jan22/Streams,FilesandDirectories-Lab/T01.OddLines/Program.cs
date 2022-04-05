using System;
using System.IO;

namespace T01.OddLines
{
    public class OddLines
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                using (StreamReader reader = new StreamReader(@"D:\ProgramProjects\SoftuniEducation\C# Advanced\advanced-jan22\Streams,FilesandDirectories-Lab\T01.OddLines\input.txt"))
                {
                    int index = 0;
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (index % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }
                        index++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
