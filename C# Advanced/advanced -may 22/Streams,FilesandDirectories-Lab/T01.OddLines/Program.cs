namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                var reader = new StreamReader(inputFilePath);
                using (reader)
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
