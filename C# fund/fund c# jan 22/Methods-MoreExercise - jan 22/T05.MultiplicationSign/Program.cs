using System;

namespace T05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            double thirdNum = double.Parse(Console.ReadLine());
            double[] nums = { firstNum, secondNum, thirdNum };
            PrintTheProduct(nums);
        }
        static void PrintTheProduct(double[] nums)
        {
            if (CheckIsTheNumEqualToZero(nums))
            {
                Console.WriteLine("zero");
            }
            else if (CheckIsCountOfNegativeNumsIsEven(CounterOfNegativeNumber(nums)) )
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
        static int CounterOfNegativeNumber(double[] nums)
        {
            int counter = 0;
            foreach (var item in nums)
            {
                if (item < 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        static bool CheckIsCountOfNegativeNumsIsEven(int counter)
        {
            if (counter % 2 == 0 )
            {
                return true;
            }
            return false;
        }
        static bool CheckIsTheNumEqualToZero(double[] nums)
        {
            foreach (var item in nums)
            {
                if (item == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
