using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.Push("Fist");
            stack.Push("Second");
            stack.Push("Third");
            Console.WriteLine(stack.IsEmpty());
            Stack<string> toAdd = new Stack<string>(new string[] { "Hi", "Hello", "What's up" });
            stack.AddRange(toAdd);
            
        }
    }
}
