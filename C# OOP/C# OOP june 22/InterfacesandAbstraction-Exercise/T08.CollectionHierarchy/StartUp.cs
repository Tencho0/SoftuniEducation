namespace T08.CollectionHierarchy
{
    using System;
    using Models;
    using Models.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] givenInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int countToRemove = int.Parse(Console.ReadLine());

            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection =
                new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            AddToTheCollection(addCollection, givenInput);
            AddToTheCollection(addRemoveCollection, givenInput);
            AddToTheCollection(myList, givenInput);

            RemoveFromTheCollection(addRemoveCollection, countToRemove);
            RemoveFromTheCollection(myList, countToRemove);
        }

        private static void RemoveFromTheCollection(IAddRemoveCollection<string> collection, int countToRemove)
        {
            for (int i = 0; i < countToRemove; i++)
                Console.Write(collection.Remove() + " ");
            Console.WriteLine();
        }

        private static void AddToTheCollection(IAddCollection<string> collection, string[] givenInput)
        {
            foreach (var currWord in givenInput)
                Console.Write(collection.AddCollection(currWord) + " ");
            Console.WriteLine();
        }
    }
}
