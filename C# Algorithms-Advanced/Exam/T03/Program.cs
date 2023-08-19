using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Item> items = new List<Item>();
        for (int i = 0; i < n; i++)
        {
            string[] itemInfo = Console.ReadLine().Split();
            items.Add(new Item
            {
                Name = itemInfo[0],
                Weight = int.Parse(itemInfo[1]),
                Value = int.Parse(itemInfo[2])
            });
        }

        int p = int.Parse(Console.ReadLine());
        Dictionary<string, List<string>> relatedPairs = new Dictionary<string, List<string>>();
        for (int i = 0; i < p; i++)
        {
            string[] pairInfo = Console.ReadLine().Split();
            string item1 = pairInfo[0];
            string item2 = pairInfo[1];

            if (!relatedPairs.ContainsKey(item1))
                relatedPairs[item1] = new List<string>();
            if (!relatedPairs.ContainsKey(item2))
                relatedPairs[item2] = new List<string>();

            relatedPairs[item1].Add(item2);
            relatedPairs[item2].Add(item1);
        }

        int storageCapacity = int.Parse(Console.ReadLine());

        HashSet<string> selectedItems = OptimizeKnapsack(items, relatedPairs, storageCapacity);

        List<string> sortedItems = selectedItems.ToList();
        sortedItems.Sort();

        foreach (string item in sortedItems)
        {
            Console.WriteLine(item);
        }
    }

    static HashSet<string> OptimizeKnapsack(List<Item> items, Dictionary<string, List<string>> relatedPairs, int capacity)
    {
        int n = items.Count;
        Dictionary<string, int> selectedItems = new Dictionary<string, int>();
        PriorityQueue<Tuple<int, int, string>> queue = new PriorityQueue<Tuple<int, int, string>>();

        for (int i = 1; i <= n; i++)
        {
            string itemName = items[i - 1].Name;
            if (!relatedPairs.ContainsKey(itemName))
            {
                queue.Enqueue(new Tuple<int, int, string>(items[i - 1].Value, items[i - 1].Weight, itemName));
            }
        }

        while (queue.Count > 0 && capacity > 0)
        {
            var itemTuple = queue.Dequeue();
            int itemValue = itemTuple.Item1;
            int itemWeight = itemTuple.Item2;
            string itemName = itemTuple.Item3;

            if (itemWeight <= capacity)
            {
                capacity -= itemWeight;
                selectedItems[itemName] = itemValue;

                if (relatedPairs.ContainsKey(itemName))
                {
                    foreach (string relatedItem in relatedPairs[itemName])
                    {
                        queue.Enqueue(new Tuple<int, int, string>(itemValue, itemWeight, relatedItem));
                    }
                }
            }
        }

        return new HashSet<string>(selectedItems.Keys);
    }

    class PriorityQueue<T>
    {
        private List<T> heap = new List<T>();
        private readonly IComparer<T> comparer;

        public PriorityQueue() : this(Comparer<T>.Default) { }

        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Count => heap.Count;

        public void Enqueue(T item)
        {
            heap.Add(item);
            int i = Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (comparer.Compare(heap[parent], item) <= 0)
                    break;
                heap[i] = heap[parent];
                i = parent;
            }
            heap[i] = item;
        }

        public T Dequeue()
        {
            T firstItem = heap[0];
            int lastItemIndex = Count - 1;
            T lastItem = heap[lastItemIndex];
            heap.RemoveAt(lastItemIndex);

            if (lastItemIndex > 0)
            {
                int i = 0;
                while (true)
                {
                    int childIndex = 2 * i + 1;
                    if (childIndex >= lastItemIndex)
                        break;
                    int rightChild = childIndex + 1;
                    if (rightChild <= lastItemIndex && comparer.Compare(heap[rightChild], heap[childIndex]) < 0)
                        childIndex = rightChild;
                    if (comparer.Compare(lastItem, heap[childIndex]) <= 0)
                        break;
                    heap[i] = heap[childIndex];
                    i = childIndex;
                }
                heap[i] = lastItem;
            }
            return firstItem;
        }
    }
}
