using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Custom_Doubly_Linked_List
{
    public class Linked_List
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void AddHead(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }
        }

        public void PrintList()
        {
            Node currentNode = Head;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
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
    }
}
