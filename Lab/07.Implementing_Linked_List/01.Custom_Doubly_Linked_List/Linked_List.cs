using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace _01.Custom_Linked_List
{
   public class Linked_List
    {
        public Node Head { get; set; }

        public void AddHead(Node node)
        {
            node.Next = Head;
            Head = node;
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
