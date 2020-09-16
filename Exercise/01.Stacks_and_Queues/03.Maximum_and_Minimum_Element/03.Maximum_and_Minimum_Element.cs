using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfInputLines = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < countOfInputLines; i++)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands.Length == 2)
                {
                    int elemnetToAdd = int.Parse(commands[1]);
                    stack.Push(elemnetToAdd);
                }
                else
                {
                    switch (commands[0])
                    {
                        case "2":
                            stack.Pop();
                            break;
                        case "3":
                            if (stack.Any())
                            {
                                Console.WriteLine(stack.Max());
                            }
                            break;
                        case "4":
                            if (stack.Any())
                            {
                                Console.WriteLine(stack.Min());
                            }
                            break;
                    }
                }
            }

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
