using System;

namespace _02.Custom_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> myCustomStack = new CustomStack<int>();

            for (int i = 1; i <= 5; i++)
            {
                myCustomStack.Push(i);
            }

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Poped element: {myCustomStack.Pop()}");
            }

            Console.WriteLine("Print stack");
            myCustomStack.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine($"Peeked element {myCustomStack.Peek()}");
            Console.WriteLine($"Stack count {myCustomStack.Count}");
            myCustomStack.Pop();
            myCustomStack.Pop();
            myCustomStack.Pop();
        }
    }
}
