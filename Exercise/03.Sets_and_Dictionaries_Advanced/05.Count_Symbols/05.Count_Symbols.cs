using System;
using System.Collections.Generic;

namespace _05.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var timesOfOccurrences = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];

                if (!timesOfOccurrences.ContainsKey(currChar))
                {
                    timesOfOccurrences.Add(currChar, 1);
                }
                else
                {
                    timesOfOccurrences[currChar]++;
                }
            }

            foreach (var currChar in timesOfOccurrences)
            {
                Console.WriteLine($"{currChar.Key}: {currChar.Value} time/s");
            }
        }
    }
}
