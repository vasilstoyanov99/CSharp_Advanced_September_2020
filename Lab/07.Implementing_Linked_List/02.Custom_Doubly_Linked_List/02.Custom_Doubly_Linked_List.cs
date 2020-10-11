using System;

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

            list.PrintList();
            Console.WriteLine(new string('-', 10));
            list.PrintListReverse();
        }
    }
}
