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
            doublyLinkedList.AddFirst(new Node(4));

            doublyLinkedList.ForEach(node =>
            {
               // Console.WriteLine("In action: ");
                Console.WriteLine(node.Value);
            });
            Console.WriteLine("Reversed");
            doublyLinkedList.Reverse();
            doublyLinkedList.ForEach(node =>
            {
               // Console.WriteLine("In action: ");
                Console.WriteLine(node.Value);
            });

            Console.WriteLine("Reversed");
            doublyLinkedList.Reverse();
            doublyLinkedList.ForEach(node =>
            {
               // Console.WriteLine("In action: ");
                Console.WriteLine(node.Value);
            });
        }
    }
}
