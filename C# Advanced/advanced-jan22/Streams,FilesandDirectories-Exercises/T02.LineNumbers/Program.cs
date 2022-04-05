namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            string[] givenFile = File.ReadAllLines(inputFilePath);
            for (int i = 0; i < givenFile.Length; i++)
            {
                string currLine = givenFile[i];
                int countOfLetters = currLine.Count(char.IsLetter);
                int countofPuncts = currLine.Count(char.IsPunctuation);
                string line = $"Line {i + 1}: {currLine} ({countOfLetters})({countofPuncts})";
                sb.AppendLine(line);
            }
            File.WriteAllText(outputFilePath, sb.ToString().Trim());
        }
    }
}
