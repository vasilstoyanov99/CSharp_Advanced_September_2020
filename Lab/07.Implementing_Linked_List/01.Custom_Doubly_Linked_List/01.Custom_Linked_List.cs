using System;

namespace _01.Custom_Linked_List
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Linked_List list = new Linked_List();

            for (int i = 0; i < 10; i++)
            {
                list.AddHead(new Node(i));
            }

            list.PrintList();
        }
    }
}
