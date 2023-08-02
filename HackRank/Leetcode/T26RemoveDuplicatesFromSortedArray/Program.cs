namespace T26RemoveDuplicatesFromSortedArray
{
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            int k = solution.RemoveDuplicates(nums);
            Console.WriteLine(k);
        }
    }
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                    dict[nums[i]]++;
                else if (!dict.ContainsKey(nums[i]))
                {
                    k++;
                    dict.Add(nums[i], 1);
                }
            }

            return k;
        }
    }
}