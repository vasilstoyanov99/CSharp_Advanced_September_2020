using System;
using System.Collections.Generic;

namespace _4.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = stack.Pop();
                    int lenght = i - startIndex + 1;
                    string subExpression = input.Substring(startIndex, lenght);
                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}
