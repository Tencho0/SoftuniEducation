namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StringBuilder sb = new StringBuilder();
            using (reader)
            {
                int index = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (index % 2 == 0)
                    {
                        line = Replace(line);
                        line = Reverse(line);
                        sb.AppendLine(line);
                    }
                    index++;
                    line = reader.ReadLine();
                }
            }
            return sb.ToString().Trim();
        }

        private static string Reverse(string line)
        {
            return string.Join(" ", line.Split(' ').Reverse());
        }

        private static string Replace(string line)
        {
            return line.Replace('-', '@')
                .Replace(',', '@')
                .Replace('.', '@')
                .Replace('!', '@')
                .Replace('?', '@');
        }
    }
}
