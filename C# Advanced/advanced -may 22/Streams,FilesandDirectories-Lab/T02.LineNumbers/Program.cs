using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                var reader = new StreamReader(inputFilePath);
                using (reader)
                {
                    int index = 1;
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine($"{index}. {line}");
                        index++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }

}
