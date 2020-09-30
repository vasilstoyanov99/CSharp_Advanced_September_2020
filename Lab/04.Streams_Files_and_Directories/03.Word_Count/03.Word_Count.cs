using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string>();
            var matchesCount = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                string allWords = reader.ReadLine();
                words = allWords.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < words.Count; i++)
                {
                    matchesCount.Add(words[i], 0);
                }
            }

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../result.txt"))
                {
                    string read = reader.ReadLine().ToLower();

                    while (read != null)
                    {
                        char[] separetors = new char[] { ' ', '?', '!', '.', ',', ':', '-', '_' };
                        string[] wordsOnTheLine = read.ToLower().Split(separetors, StringSplitOptions.RemoveEmptyEntries).ToArray();

                        for (int i = 0; i < wordsOnTheLine.Length; i++)
                        {
                            string currWord = wordsOnTheLine[i];

                            if (matchesCount.ContainsKey(currWord))
                            {
                                matchesCount[currWord]++;
                            }
                        }

                        read = reader.ReadLine();
                    }

                    matchesCount = matchesCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

                    foreach (var word in matchesCount)
                    {
                        writer.Write($"{word.Key} - {word.Value}");
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}
