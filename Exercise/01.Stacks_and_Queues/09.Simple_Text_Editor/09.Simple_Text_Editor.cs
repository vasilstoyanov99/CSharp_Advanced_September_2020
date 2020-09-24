using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Stack<char> stack = new Stack<char>();
            var stackAfterCommandOne = new Stack<char[]>();
            var stackBeforeCommandTwo = new Stack<char[]>();
            var historyOfCommands = new Stack<int>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "1":
                        char[] arrayCopy = new char[stack.Count];
                        stack.CopyTo(arrayCopy, 0);
                        stackAfterCommandOne.Push(arrayCopy);
                        historyOfCommands.Push(1);
                        AddStringTo(stack, command[1]);
                        break;
                    case "2":
                        char[] copy = new char[stack.Count];
                        stack.CopyTo(copy, 0);
                        stackBeforeCommandTwo.Push(copy);
                        historyOfCommands.Push(2);
                        RemoveElementsFrom(stack, int.Parse(command[1]));
                        break;
                    case "3":
                        PrintElementFromPosition(stack, int.Parse(command[1]));
                        break;
                    case "4":
                        char[] beforeCommand = UndoCommand(stackAfterCommandOne, stackBeforeCommandTwo, historyOfCommands);
                       stack = new Stack<char>(beforeCommand.Reverse());
                        break;
                }
            }
        }

        static void AddStringTo(Stack<char> stack, string toAdd)
        {
            for (int i = 0; i < toAdd.Length; i++)
            {
                stack.Push(toAdd[i]);
            }
        }

        static void RemoveElementsFrom(Stack<char> stack, int nElementsToRemove)
        {
            for (int i = 0; i < nElementsToRemove; i++)
            {
                stack.Pop();
            }
        }

        static void PrintElementFromPosition(Stack<char> stack, int position)
        {
            int nOfPeeks = stack.Count - position;

            if (nOfPeeks == 0)
            {
                Console.WriteLine(stack.Peek());
            }
            else
            {
                List<char> temp = new List<char>();

                for (int peek = 1; peek <= nOfPeeks + 1; peek++)
                {
                    if (peek == nOfPeeks + 1)
                    {
                        Console.WriteLine(stack.Peek());
                    }
                    else
                    {
                        char poped = stack.Pop();
                        temp.Add(poped);
                    }
                }

                for (int i = temp.Count - 1; i >= 0; i--)
                {
                    stack.Push(temp[i]);
                    temp.RemoveAt(i);
                }
            }
        }

        static char[] UndoCommand(Stack<char[]> stackAfterCommandOne, Stack<char[]> stackBeforeCommandTwo,
           Stack<int> historyOfCommands)
        {
            int commamdNumber = historyOfCommands.Pop();

            if (commamdNumber == 1)
            {
                return stackAfterCommandOne.Pop();
            }
            else
            {
                return stackBeforeCommandTwo.Pop();
            }
        }
    }
}
