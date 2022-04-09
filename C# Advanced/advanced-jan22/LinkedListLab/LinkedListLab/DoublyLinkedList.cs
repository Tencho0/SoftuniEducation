using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListLab
{
    public class DoublyLinkedList
    {
        private bool isReversed = false;
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }
        public void Reverse()
        {
            isReversed = !isReversed;
        }
        public void ForEach(Action<Node> action)
        {
            var node = Head;
            if (isReversed)
            {
                node = Tail;
            }
            while (node != null)
            {
                action(node);
                if (isReversed)
                {
                    node = node.Previous;
                }
                else
                {
                    node = node.Next;
                }
            }
        }
        public Node[] ToArray()
        {
            Node[] array = new Node[Count];
            var node = Head;
            int index = 0;
            while (node != null)
            {
                array[index++] = node;
                node = node.Next;
            }
            return array;
        }
        public Node RemoveFirst()
        {
            if (Head == null)
            {
                return null;
            }
            Count--;
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
            Count--;
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
            Count++;
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
            Count++;
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
