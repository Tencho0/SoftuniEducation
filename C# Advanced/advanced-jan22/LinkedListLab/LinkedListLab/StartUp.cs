using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<int> doublyLinkedList = new CustomDoublyLinkedList<int>();

            doublyLinkedList.AddFirst(new Node<int>(1));
            doublyLinkedList.AddFirst(new Node<int>(2));
            doublyLinkedList.AddFirst(new Node<int>(3));
            doublyLinkedList.AddFirst(new Node<int>(4));

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
