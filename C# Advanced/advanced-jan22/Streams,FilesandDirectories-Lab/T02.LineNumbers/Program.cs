using System.IO;

namespace RewriteFileWithLineNumbers
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
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    int index = 0;
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