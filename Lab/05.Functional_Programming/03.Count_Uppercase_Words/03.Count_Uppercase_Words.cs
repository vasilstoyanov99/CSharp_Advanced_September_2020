using System;

namespace _03.Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                PrintResult(CheckIfWordStartsWithUppercase, words[i]);
            }
            
        }

        static void PrintResult(Func<string, bool> fucn, string word)
        {
            bool result = CheckIfWordStartsWithUppercase(word);

            if (result)
            {
                Console.WriteLine(word);
            }
        }

        static bool CheckIfWordStartsWithUppercase(string word)
        {
            if (char.IsLetter(word[0]))
            {
                return char.IsUpper(word[0]);
            }

            return false;
        }
    }
}
