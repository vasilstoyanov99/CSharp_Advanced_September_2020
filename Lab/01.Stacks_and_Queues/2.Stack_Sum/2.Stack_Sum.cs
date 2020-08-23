using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>(numbers);
            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] commands = input.Split();

                switch (commands[0])
                {
                    case "add":
                        int firstNumber = int.Parse(commands[1]);
                        int secondNumber = int.Parse(commands[2]);
                        stack.Push(firstNumber);
                        stack.Push(secondNumber);
                        break;
                    case "remove":
                        int countOfElementsToRemove = int.Parse(commands[1]);

                        if (stack.Count >= countOfElementsToRemove)
                        {
                            for (int i = 0; i < countOfElementsToRemove; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;

                }

                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
