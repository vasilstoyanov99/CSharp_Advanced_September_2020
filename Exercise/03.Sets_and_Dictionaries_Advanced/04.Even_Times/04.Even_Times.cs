using System;
using System.Collections.Generic;

namespace _04.Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currNumber))
                {
                    numbers.Add(currNumber, 1);
                }
                else
                {
                    numbers[currNumber]++;
                }
            }

            foreach (var currNumber in numbers)
            {
                if (currNumber.Value % 2 == 0)
                {
                    Console.WriteLine(currNumber.Key);
                    break;
                }
            }
        }
    }
}
