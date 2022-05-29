namespace ExtractBytes
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\example.png";
            string bytesFilePath = @"..\..\..\bytes.txt";
            string outputPath = @"..\..\..\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using StreamReader streamReader = new StreamReader(bytesFilePath);
            byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
            var bytesList = new List<string>();
            var sb = new StringBuilder();

            while (!streamReader.EndOfStream)
            {
                bytesList.Add(streamReader.ReadLine());
            }
            foreach (var item in fileBytes)
            {
                if (bytesList.Contains(item.ToString()))
                {
                    sb.AppendLine(item.ToString());
                }
            }
            using StreamWriter file = new StreamWriter(outputPath);
            file.WriteLine(sb.ToString().Trim());

        }
    }
}