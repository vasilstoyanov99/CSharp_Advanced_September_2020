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
            node.Next = Head;
            Head = node;
        }

        public void AddTail(Node node)
        {

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
    }
}
