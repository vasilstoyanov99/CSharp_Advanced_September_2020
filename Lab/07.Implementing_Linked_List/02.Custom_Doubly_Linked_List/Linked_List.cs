using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Custom_Doubly_Linked_List
{
    public class Linked_List
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void AddHead(Node newHead)
        {
            if (Head == null)
            {
                Head = newHead;
                Tail = newHead;
            }
            else
            {
                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }
        }

        public void AddLast(Node newTail)
        {
            if (Tail == null)
            {
                Tail = newTail;
                Head = newTail;
            }
            else
            {
                newTail.Previous = Tail;
                Tail.Next = newTail;
                Tail = newTail;
            }
        }

        public void ForEach(Action<Node> action)
        {
            Node currNode = Head;

            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Next;
            }
        }

        public Node RemoveFirst()
        {
            Node oldHead = Head;
            Head = Head.Next;
            Head.Previous = null;
            return oldHead;
        }

        public Node RemoveLast()
        {
            Node oldTail = Tail;
            Tail = Tail.Previous;
            Tail.Next = null;
            return oldTail;
        }

        public int Peek()
        {
            return Head.Value;
        }

        public void PrintList()
        {
            ForEach(node => Console.WriteLine(node.Value));
        }

        public void PrintListReverse()
        {
            Node currNode = Tail;

            while (currNode != null)
            {
                Console.WriteLine(currNode.Value);
                currNode = currNode.Previous;
            }
        }

        public Node[] ToArray()
        {
            List<Node> list = new List<Node>();
            this.ForEach(node => list.Add(node));
            return list.ToArray();
        }
    }
}
