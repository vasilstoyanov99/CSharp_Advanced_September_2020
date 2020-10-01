using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");
            var wordCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                wordCount.Add(words[i].ToLower(), 0);
            }

            string[] lines = File.ReadAllLines("../../../text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                GetWordsMatchCount(wordCount, lines[i].ToLower());
            }

            string[] result = new string[wordCount.Count];
            int index = 0;

            foreach (var word in wordCount.OrderByDescending(x => x.Value))
            {
                result[index] = $"{word.Key} - {word.Value}";
                index++;
            }

            File.WriteAllLines("../../../actualResult.txt", result);
        }

        static void GetWordsMatchCount(Dictionary<string, int> wordCount, string line)
        {
            char[] separetors = new char[] { ' ', '?', '!', '.', ',', ':', ';', '\'', '-', '_' };
            string[] words = line.Split(separetors, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[i];

                if (wordCount.ContainsKey(currWord))
                {
                    wordCount[currWord]++;
                }
            }
        }
    }
}
