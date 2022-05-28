namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            int count = 0;
            List<string> allLines = new List<string>();
            foreach (var line in lines)
            {
                count++;
                int lettersCount = line.Count(x => char.IsLetter(x));
                int punctuationCount = line.Count(x => char.IsPunctuation(x));
                string modifiedLine = $"Line {count}: {line} ({lettersCount})({punctuationCount})";
                allLines.Add(modifiedLine);
            }
            File.WriteAllLines(outputFilePath, allLines);


            // StreamReader reader = new StreamReader(inputFilePath);
            // StreamWriter writer = new StreamWriter(outputFilePath);
            // using (reader)
            // {
            //     using (writer)
            //     {
            //         int index = 1;
            //         string line = reader.ReadLine();
            //
            //         int lettersCount = 0;
            //         int punctuationCount = 0;
            //
            //         while (line != null)
            //         {
            //             lettersCount = line.Where(x => char.IsLetter(x)).Count();
            //             punctuationCount = line.Where(x => char.IsPunctuation(x)).Count();
            //             writer.WriteLine($"Line {index}: {line} ({lettersCount})({punctuationCount})");
            //             index++;
            //             line = reader.ReadLine();
            //         }
            //     }
            // }
        }
    }
}
