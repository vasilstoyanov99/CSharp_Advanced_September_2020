using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Generic_Swap_Method_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfInputs = int.Parse(Console.ReadLine());
            var allboxes = new List<Box<string>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                var value = Console.ReadLine();
                Box<string> box = new Box<string>(value);
                allboxes.Add(box);
            }

            var indexesToSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(allboxes, indexesToSwap[0], indexesToSwap[1]);

            foreach (var box in allboxes)
            {
                Console.WriteLine(box);
            }

        }

        static void Swap(List<Box<string>> allBoxes, int fistIndex, int secondIndex)
        {
            var temp = allBoxes[fistIndex];
            allBoxes[fistIndex] = allBoxes[secondIndex];
            allBoxes[secondIndex] = temp;
        }
    }
}
