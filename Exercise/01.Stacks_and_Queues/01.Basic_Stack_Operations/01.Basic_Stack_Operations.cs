using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int stackElements = data[0];
            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).Take(stackElements));

            if (stack.Count <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            int countOfElementsToPop = data[1];

            if (stack.Count >= countOfElementsToPop)
            {
                for (int i = 0; i < countOfElementsToPop; i++)
                {
                    stack.Pop();
                }

                if (stack.Count <= 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            int numberToSearch = data[2];
            bool isNumberFound = false;

            foreach (var number in stack)
            {
                if (number == numberToSearch)
                {
                    Console.WriteLine("true");
                    isNumberFound = true;
                    break;
                }
            }

            if (!isNumberFound)
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
