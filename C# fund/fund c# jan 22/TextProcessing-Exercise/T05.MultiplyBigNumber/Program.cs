using System;
using System.Text;

namespace T05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string firstNum = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());
            int reminder = 0;
            if (secondNum == 0 || firstNum == "0")
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                int currDigit = int.Parse(firstNum[i].ToString());
                int product = currDigit * secondNum + reminder;
                int result = product % 10;
                reminder = product / 10;
                sb.Insert(0, result);
            }
            if (reminder >0)
            {
                sb.Insert(0, reminder);
            }
            Console.WriteLine(sb);
        }
    }
}
