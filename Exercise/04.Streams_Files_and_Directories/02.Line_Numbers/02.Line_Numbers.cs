using System;
using System.IO;
using System.Text;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            var result = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = GetLettersCount(lines[i]);
                int punctuationMarksCount = GetPunctuationMarksCount(lines[i]);
                result[i] = $"Line {i + 1}: -I was quick to judge him, but it wasn't his fault. ({lettersCount})({punctuationMarksCount})";
            }

            File.WriteAllLines("../../../output.txt", result);
        }

        static int GetLettersCount(string line)
        {
            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currChar = line[i];

                if (char.IsLetter(currChar))
                {
                    counter++;
                }
            }

            return counter;
        }

        static int GetPunctuationMarksCount(string line)
        {
            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currChar = line[i];

                if (char.IsPunctuation(currChar))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
