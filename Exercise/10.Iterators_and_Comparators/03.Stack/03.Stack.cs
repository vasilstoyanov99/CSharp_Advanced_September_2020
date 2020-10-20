using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> myCustomStack = new CustomStack<int>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                List<string> command = input.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).ToList();

                switch (command[0])
                {
                    case "Push":
                        int[] numbers = command.Skip(1).Select(int.Parse).ToArray();

                        foreach (var number in numbers)
                        {
                            myCustomStack.Push(number);
                        }

                        break;
                    case "Pop":
                        try
                        {
                            myCustomStack.Pop();
                        }
                        catch (InvalidOperationException msg)
                        {
                            Console.WriteLine(msg.Message);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            if (myCustomStack.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, myCustomStack));
                Console.WriteLine(String.Join(Environment.NewLine, myCustomStack));
            }


        }
    }
}
