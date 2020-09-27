using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setsSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> n = new HashSet<int>();
            HashSet<int> m = new HashSet<int>();

            for (int i = 0; i < setsSize[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                n.Add(number);
            }

            for (int i = 0; i < setsSize[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                m.Add(number);
            }

            var numbersInBothSets = new List<int>(); 

            foreach (var numberOne in n)
            {
                foreach (var numberTwo in m)
                {
                    if (numberOne == numberTwo)
                    {
                        Console.Write($"{numberOne} ");
                    }
                }
            }
        }
    }
}
