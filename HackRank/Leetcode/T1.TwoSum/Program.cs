namespace T1.TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 2, 7, 11, 15 };
            var target = 9;
            var result = solution.TwoSum(nums, target);
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (var i = 0; i <= nums.Length - 1; i++)
            {
                for (var j = i + 1; j <= nums.Length - 1; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }
    }
}