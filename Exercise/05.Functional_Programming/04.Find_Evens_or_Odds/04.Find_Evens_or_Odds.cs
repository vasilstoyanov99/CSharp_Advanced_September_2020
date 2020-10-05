using System;
using System.Linq;

namespace _04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersRange = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = numbersRange[0];
            int end = numbersRange[1];
            string type = Console.ReadLine();
            Predicate<int> checker = IsNumberEven;

            if (type == "odd")
            {
                checker = IsNumberOdd;
            }

            for (int currNumber = start; currNumber <= end; currNumber++)
            {
                if (checker(currNumber))
                {
                    Console.Write($"{currNumber} ");
                }
            }
        }

        static bool IsNumberEven(int number)
        {
            return number % 2 == 0;
        }

        static bool IsNumberOdd(int number)
        {
            return number % 2 != 0;
        }
    }
}
