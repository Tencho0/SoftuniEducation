using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_WordCruncher
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");
            var target = Console.ReadLine();

            WordCruncher wc = new WordCruncher(input, target);

            foreach (var path in wc.GetPaths())
            {
                Console.WriteLine(path);
            }
        }
    }

    public class WordCruncher
    {
        private SortedSet<string> results = new SortedSet<string>();
        private List<Node> permutation = new List<Node>();

        public WordCruncher(string[] input, string target)
        {
            permutation = GeneratePermutations(input.OrderBy(s => s).ToList(), target);

            foreach (var path in this.GetAllPaths())
            {
                var result = string.Join(' ', path);
                if (!this.results.Contains(result))
                {
                    this.results.Add(result);
                }
            }
        }

        public IEnumerable<string> GetPaths()
        {
            foreach (var result in this.results)
            {
                yield return result;
            }
        }

        public IEnumerable<IEnumerable<string>> GetAllPaths()
        {
            List<string> way = new List<string>();
            foreach (var key in VisitPath(permutation, new List<string>()))
            {
                if (key == null)
                {
                    yield return way;
                    way = new List<string>();
                }
                else
                {
                    way.Add(key);
                }
            }
        }

        private List<Node> GeneratePermutations(List<string> input, string target)
        {
            if (string.IsNullOrEmpty(target) || input.Count() == 0)
            {
                return null;
            }

            List<Node> returnValues = null;
            for (int i = 0; i < input.Count(); i++)
            {
                var key = input[i];
                if (target.StartsWith(key))
                {
                    var node = new Node()
                    {
                        Key = key,
                        Value = GeneratePermutations(input.Where((s, index) => index != i).ToList(),
                        target.Substring(key.Length))
                    };

                    if (node.Value == null && node.Key != target)
                    {
                        continue;
                    }

                    if (returnValues == null)
                        returnValues = new List<Node>();
                    returnValues.Add(node);
                }
            }
            return returnValues;
        }

        private IEnumerable<string> VisitPath(List<Node> permutation, List<string> path)
        {
            if (permutation == null)
            {
                foreach (var pathItem in path)
                    yield return pathItem;
                yield return null;
            }
            else
            {
                foreach (Node node in permutation)
                {
                    path.Add(node.Key);
                    foreach (var item in VisitPath(node.Value, path))
                    {
                        yield return item;
                    }
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }

    public class Node
    {
        public string Key { get; set; }

        public List<Node> Value { get; set; }
    }
}


//namespace T06WordCruncher
//{
//    using System;
//    using System.Text;
//    using System.Linq;
//    using System.Collections.Generic;

//    internal class Program
//    {
//        private static string target;
//        private static Dictionary<int, List<string>> wordsByIndex;
//        private static Dictionary<string, int> wordsCount;
//        private static LinkedList<string> usedWords;

//        static void Main(string[] args)
//        {
//            var words = Console.ReadLine().Split();
//            target = Console.ReadLine();
//            usedWords = new LinkedList<string>();

//            wordsByIndex = new Dictionary<int, List<string>>();
//            wordsCount = new Dictionary<string, int>();

//            foreach (var word in words)
//            {
//                var index = target.IndexOf(word);

//                if (index == -1)
//                {
//                    continue;
//                }

//                if (wordsCount.ContainsKey(word))
//                {
//                    wordsCount[word] += 1;
//                    continue;
//                }

//                wordsCount[word] = 1;

//                while (index != -1)
//                {
//                    if (!wordsByIndex.ContainsKey(index))
//                    {
//                        wordsByIndex[index] = new List<string>();
//                    }

//                    wordsByIndex[index].Add(word);

//                    index = target.IndexOf(word, index + 1);
//                }
//            }

//            GenerateSolutions(0);
//        }

//        private static void GenerateSolutions(int index)
//        {
//            if (index == target.Length)
//            {
//                Console.WriteLine(string.Join(" ", usedWords));
//                return;
//            }

//            if (!wordsByIndex.ContainsKey(index))
//            {
//                return;
//            }

//            foreach (var word in wordsByIndex[index])
//            {
//                if (wordsCount[word] == 0)
//                {
//                    continue;
//                }

//                wordsCount[word] -= 1;
//                usedWords.AddLast(word);

//                GenerateSolutions(index + word.Length);

//                wordsCount[word] += 1;
//                usedWords.RemoveLast();
//            }
//        }
//    }
//}