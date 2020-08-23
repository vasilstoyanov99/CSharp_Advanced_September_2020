using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();
            var stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                int result = 0;
                string firstNumber = stack.Pop();
                string operand = stack.Pop();
                string secondNumber = stack.Pop();

                switch (operand)
                {
                    case "+":
                        result = int.Parse(firstNumber) + int.Parse(secondNumber);
                        stack.Push(result.ToString());
                        break;
                    case "-":
                        result = int.Parse(firstNumber) - int.Parse(secondNumber);
                        stack.Push(result.ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
