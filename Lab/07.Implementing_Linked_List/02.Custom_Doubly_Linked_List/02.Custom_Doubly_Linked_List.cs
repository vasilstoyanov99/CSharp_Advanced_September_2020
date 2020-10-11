using System;
using System.Collections.Specialized;

namespace _02.Custom_Doubly_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Linked_List list = new Linked_List();

            for (int i = 0; i < 5; i++)
            {
                list.AddHead(new Node(i));
            }

            for (int i = -5; i <= 0; i++)
            {
                list.AddLast(new Node(i));
            }

            list.PrintList();
            Console.WriteLine(new string('-', 10));

            list.RemoveFirst();
            list.RemoveFirst();
            list.RemoveLast();
            list.RemoveLast();
            list.PrintList();

        }
    }
}
