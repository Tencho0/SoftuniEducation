using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListLab
{
    public class DoublyLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public Node RemoveFirst()
        {
            if (Head == null)
            {
                return null;
            }

            var previous = Head;
            var next = Head.Next;
            if (next != null)
            {
                next.Previous = null;
            }
            else
            {
                Tail = null;
            }
            Head = next;
            return previous;
        }
        public Node RemoveLast()
        {
            if (Tail == null)
            {
                return null;
            }

            var previous = Tail;
            var next = Tail.Previous;
            if (next != null)
            {
                next.Next = null;
            }
            else
            {
                Head = null;
            }
            Tail = next;
            return previous;
        }
        public void AddFirst(Node node)
        {
            if (!ChekIfFirstElementInList(node))
            {
                Node previousHead = Head;
                Head = node;
                previousHead.Previous = Head;
                Head.Next = previousHead;
            }
        }
        public void AddLast(Node node)
        {
            if (!ChekIfFirstElementInList(node))
            {
                Node previousTail = Tail;
                Tail = node;
                previousTail.Next = Tail;
                Tail.Previous = previousTail;
            }
        }

        private bool ChekIfFirstElementInList(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return true;
            }

            return false;
        }
    }
}
