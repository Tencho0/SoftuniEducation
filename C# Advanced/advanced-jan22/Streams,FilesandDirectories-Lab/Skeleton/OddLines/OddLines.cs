
namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);

            int count = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                if (count % 2 == 0)
                {
                    writer.WriteLine(line);
                }
                count++;
                line = reader.ReadLine();
            }
        }
    }
}
