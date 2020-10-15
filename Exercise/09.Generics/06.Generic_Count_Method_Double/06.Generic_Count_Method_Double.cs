using System;
using System.Collections.Generic;

namespace _06.Generic_Count_Method_Double
{
   public class Program
    {
        static void Main(string[] args)
        {
            var numberOfInputs = int.Parse(Console.ReadLine());
            var allboxes = new List<Box<double>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                var value = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(value);
                allboxes.Add(box);
            }

            var elementToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(Compare(elementToCompare, allboxes));
        }

        static int Compare(double element, List<Box<double>> allBoxes)

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
