using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var leftHalfSymbols = new Stack<char>();

            if (input.Length % 2 == 0)
            {
                for (int i = 0; i < input.Length / 2; i++)
                {
                    switch (input[i])
                    {
                        case '(':
                            leftHalfSymbols.Push(input[i]);
                            break;
                        case '{':
                            leftHalfSymbols.Push(input[i]);
                            break;
                        case '[':
                            leftHalfSymbols.Push(input[i]);
                            break;
                        case ' ':
                            break;
                        default:
                            Console.WriteLine("NO");
                            return;
                    }
                }

                var rightHalfSymbols = new Queue<char>();

                for (int i = input.Length / 2; i < input.Length; i++)
                {
                    switch (input[i])
                    {
                        case ')':
                            rightHalfSymbols.Enqueue(input[i]);
                            break;
                        case '}':
                            rightHalfSymbols.Enqueue(input[i]);
                            break;
                        case ']':
                            rightHalfSymbols.Enqueue(input[i]);
                            break;
                        case ' ':
                            break;
                        default:
                            Console.WriteLine("NO");
                            return;
                    }
                }

                int counter = 0;

                for (int i = 0; i < input.Length / 2; i++)
                {
                    char leftSymbol = leftHalfSymbols.Pop();
                    char rightSymbol = rightHalfSymbols.Dequeue();

                    switch (leftSymbol)
                    {
                        case '(':
                            if (rightSymbol == ')')
                            {
                                counter++;
                            }
                            else
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case '{':
                            if (rightSymbol == '}')
                            {
                                counter++;
                            }
                            else
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case '[':
                            if (rightSymbol == ']')
                            {
                                counter++;
                            }
                            else
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }

                if (counter == input.Length / 2)
                {
                    Console.WriteLine("YES");
                }
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
