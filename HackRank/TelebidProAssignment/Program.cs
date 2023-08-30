using System;
using System.Linq;

namespace GoatRaftProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int goatsCount = firstLine[0];
            int maxCourses = firstLine[1];

            int[] goatWeights = new int[goatsCount];

            var goatsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < goatsCount; i++)
            {
                goatWeights[i] = goatsInput[i];
            }

            int result = MinimumRaftCapacity2(maxCourses, goatWeights);
            Console.WriteLine(result);
        }

        static int MinimumRaftCapacity2(int maxCourses, int[] goatWeights)
        {
            var goatsAsList = goatWeights.ToList();
            var rafts = new List<int>[maxCourses];
            for (int i = 0; i < maxCourses; i++)
            {
                var maxWeight = goatsAsList.Max();
                rafts[i] = new List<int>
                {
                    maxWeight
                };
                goatsAsList.Remove(maxWeight);
            }

            for (int i = 0; i < maxCourses; i++)
            {
                var maxWeight = goatsAsList.Max();
                
                var raftsWeights = new int[maxCourses];
                for (int j = 0; j < maxCourses; j++)
                {
                    raftsWeights[j] = rafts[j].Sum();
                }

                for (int j = 0; j < maxCourses; j++)
                {
                    if (raftsWeights[j] + maxWeight <= raftsWeights.Min())
                    {
                        rafts[j].Add(maxWeight);
                        break;
                    }

                    if (j == maxCourses - 1)
                    {
                        rafts[raftsWeights.ToList().IndexOf(raftsWeights.Max())].Add(maxWeight);
                    }
                }

                goatsAsList.Remove(maxWeight);
            }

            return rafts.Max(x => x.Sum());
        }

        static int MinimumRaftCapacity(int maxCourses, int[] goatWeights)
        {
            int maxGoatWeight = goatWeights.Max();
            int left = maxGoatWeight;
            int right = goatWeights.Sum();

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (CanTransport(goatWeights, mid, maxCourses))
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }

        static bool CanTransport(int[] goatWeights, int capacity, int maxCourses)
        {
            int currentCourseCapacity = 0;
            int currentCourses = 1;

            for (int i = 0; i < goatWeights.Length; i++)
            {
                int currentGoatWeight = goatWeights[i];
                if (currentCourseCapacity + currentGoatWeight <= capacity)
                {
                    currentCourseCapacity += currentGoatWeight;
                }
                else
                {
                    currentCourses++;
                    currentCourseCapacity = currentGoatWeight;
                }
            }

            return currentCourses <= maxCourses;
        }
    }
}


//namespace TelebidProAssignment
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    public class Raft
//    {
//        public static int GetMinRaftCapacity(int[] goats, int maxCourses)
//        {
//            var sortedGoats = goats.OrderByDescending(x => x).ToArray();
//            var raftCapacity = sortedGoats[0];

//            var courses = new List<List<int>>();
//            var currentCourse = new List<int>();
//            var currentCourseCapacity = 0;

//            for (int i = 0; i < sortedGoats.Length; i++)
//            {
//                var currentGoat = sortedGoats[i];
//                if (currentCourseCapacity + currentGoat <= raftCapacity)
//                {
//                    currentCourse.Add(currentGoat);
//                    currentCourseCapacity += currentGoat;
//                }
//                else
//                {
//                    courses.Add(currentCourse);
//                    currentCourse = new List<int>();
//                    currentCourse.Add(currentGoat);
//                    currentCourseCapacity = currentGoat;
//                }
//            }

//            if (currentCourse.Count > 0)
//            {
//                courses.Add(currentCourse);
//            }

//            if (courses.Count > maxCourses)
//            {
//                return GetMinRaftCapacity(goats, maxCourses + 1);
//            }

//            return raftCapacity;
//        }
//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//            var goatsCount = input[0];
//            var maxCourses = input[1];

//            var goats = new int[goatsCount];

//            var goatsInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//            for (int i = 0; i < goatsCount; i++)
//            {
//                goats[i] = goatsInput[i];
//            }

//            var minRaftCapacity = Raft.GetMinRaftCapacity(goats, maxCourses);
//            Console.WriteLine(minRaftCapacity);
//        }
//    }
//}