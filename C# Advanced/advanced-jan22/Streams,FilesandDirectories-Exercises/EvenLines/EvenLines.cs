namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StringBuilder sb = new StringBuilder();

            char[] symbols = { '-', ',', '.', '!', '?' };

            int currIndex = 0;

            string line = reader.ReadLine();
            while (line != null)
            {
                if (currIndex % 2 != 0)
                {
                    currIndex++;
                    line = reader.ReadLine();
                    continue;
                }

                foreach (var symbol in symbols)
                {
                    line = line.Replace(symbol, '@');
                }

                line = string.Join(" ", line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Reverse());

                sb.AppendLine(line);

                currIndex++;
                line = reader.ReadLine();
            }
            return sb.ToString().TrimEnd();
        }
        private static string ReverseWords(string replacedSymbols)
        {
            throw new NotImplementedException();
        }

        private static string ReplaceSymbols(string line)
        {
            throw new NotImplementedException();
        }
    }

}
