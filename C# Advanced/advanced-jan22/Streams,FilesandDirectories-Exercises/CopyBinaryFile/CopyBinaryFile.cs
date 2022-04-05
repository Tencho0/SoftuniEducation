using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream fileStreamReader = new FileStream(inputFilePath, FileMode.Open);
            using FileStream fileStreamWriter = new FileStream(outputFilePath, FileMode.Create);
            byte[] bytes = new byte[256];
            while (true)
            {
                int count = fileStreamReader.Read(bytes, 0, bytes.Length);
                if (count ==0)
                {
                    break;
                }
                fileStreamWriter.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
