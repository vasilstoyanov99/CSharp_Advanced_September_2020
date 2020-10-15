using System;
using System.Collections.Generic;

namespace _05.Generic_Count_Method_String
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

            var elementToCompare = Console.ReadLine();
            Console.WriteLine(Compare(elementToCompare, allboxes));
        }

        static int Compare(string element, List<Box<string>> allBoxes)
           
        {
            int counter = 0;

            foreach (var box in allBoxes)
            {
                if (box.Value.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
