using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            Action<List<int>> addOneToEveryNumber = Add;
            Action<List<int>> multiplyByTwoEachNumber = Multiply;
            Action<List<int>> subtractOneFromEachNumber = Subtract;
            Action<List<int>> printer = Print;

            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        addOneToEveryNumber(numbers);
                        break;
                    case "multiply":
                        multiplyByTwoEachNumber(numbers);
                        break;
                    case "subtract":
                        subtractOneFromEachNumber(numbers);
                        break;
                    case "print":
                        printer(numbers);
                        break;
                }

                input = Console.ReadLine();
            }
        }

        static void Add(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]++;
            }
        }

        static void Multiply(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] *= 2;
            }
        }

        static void Subtract(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]--;
            }
        }

        static void Print(List<int> numbers)
        {
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
