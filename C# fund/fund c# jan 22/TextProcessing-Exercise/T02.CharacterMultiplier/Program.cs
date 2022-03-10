using System;

namespace T02.CharacterMultiplier
{
    internal class Program
    {
        public static int ReturnTotalSum(string[] arr)
        {
            int totalSum = 0;
            string firstText = arr[0];
            string secondText = arr[1];

            if (firstText.Length == secondText.Length)
            {
                for (int i = 0; i < firstText.Length; i++)
                {
                    totalSum += firstText[i] * secondText[i];
                }
            }
            else
            {
                int reps = Math.Min(firstText.Length, secondText.Length);
                int index = -1;
                for (int i = 0; i < reps; i++)
                {
                    totalSum += firstText[i] * secondText[i];
                    index = i;
                }
                if (firstText.Length > secondText.Length)
                {
                    for (int i = index + 1; i < firstText.Length; i++)
                    {
                        totalSum += firstText[i];
                    }
                    //totalSum += AddToTotalSum(index, firstText, totalSum);
                }
                else
                {
                    for (int i = index + 1; i < secondText.Length; i++)
                    {
                        totalSum += secondText[i];
                    }
                    //totalSum += AddToTotalSum(index, secondText, totalSum);
                }
               // totalSum = AddToTtotalSumNotEqualLenghts(firstText, secondText, totalSum);
            }
            return totalSum;
        }
        //public static int AddToTotalSum(int index, string text, int totalSum)
        //{
        //    for (int i = index + 1; i < text.Length; i++)
        //    {
        //        totalSum += text[i];
        //    }
        //    return totalSum;
        //}
        //public static int AddToTtotalSumNotEqualLenghts(string firstText, string secondText, int totalSum)
        //{
        //    int reps = Math.Min(firstText.Length, secondText.Length);
        //    int index = -1;
        //    for (int i = 0; i < reps; i++)
        //    {
        //        totalSum += firstText[i] * secondText[i];
        //        index = i;
        //    }
        //    if (firstText.Length > secondText.Length)
        //    {
        //        totalSum += AddToTotalSum(index, firstText, totalSum);
        //    }
        //    else
        //    {
        //        totalSum += AddToTotalSum(index, secondText, totalSum);
        //    }
        //    return totalSum;
        //}

        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int totalSum = ReturnTotalSum(arr);
            Console.WriteLine(totalSum);
        }
    }
}
