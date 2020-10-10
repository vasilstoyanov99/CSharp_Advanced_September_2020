using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Custom_Linked_List
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next{ get; set; }
        public Node Previous { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}
