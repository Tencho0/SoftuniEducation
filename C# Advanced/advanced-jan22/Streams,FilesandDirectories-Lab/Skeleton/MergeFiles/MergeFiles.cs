namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using StreamReader reader = new StreamReader(firstInputFilePath);
            using StreamReader secondReader = new StreamReader(secondInputFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);


            while (true)
            {
                string firstLine = reader.ReadLine();
                string secondLine = secondReader.ReadLine();

                if (firstLine == null && secondLine == null)
                {
                    break;
                }
                else if (firstLine == null)
                {
                    writer.WriteLine(secondLine);
                }
                else if (secondLine == null)
                {
                    writer.WriteLine(firstLine);
                }
                else
                {
                    writer.WriteLine(firstLine);
                    writer.WriteLine(secondLine);
                }
            }
        }
    }
}
