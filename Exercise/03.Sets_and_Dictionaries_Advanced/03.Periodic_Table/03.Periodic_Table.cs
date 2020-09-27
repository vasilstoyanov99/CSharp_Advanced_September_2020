using System;
using System.Collections.Generic;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            var uniqueChemicalElements = new SortedSet<string>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] elements = Console.ReadLine().Split();

                for (int k = 0; k < elements.Length; k++)
                {
                    uniqueChemicalElements.Add(elements[k]);
                }
            }

            foreach (var elements in uniqueChemicalElements)
            {
                Console.Write(elements + " ");
            }
        }
    }
}
