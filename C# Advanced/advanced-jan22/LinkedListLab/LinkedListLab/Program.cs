using System;
using System.Collections.Generic;

namespace LinkedListLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.AddFirst(new Node(1));
            doublyLinkedList.AddFirst(new Node(2));
            doublyLinkedList.AddFirst(new Node(3));

            doublyLinkedList.AddLast(new Node(1));
            doublyLinkedList.AddLast(new Node(2));
            doublyLinkedList.AddLast(new Node(3));

            Console.WriteLine($"Removed First: {doublyLinkedList.RemoveFirst().Value}");
            Console.WriteLine($"Removed First: {doublyLinkedList.RemoveFirst().Value}");

            Console.WriteLine($"Removed Last: {doublyLinkedList.RemoveLast().Value}");
            Console.WriteLine($"Removed Last: {doublyLinkedList.RemoveLast().Value}");

            Node node = doublyLinkedList.Head;

            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
