using System;
using System.Linq;

namespace _09.List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperBound = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int currNumber = 1; currNumber <= upperBound; currNumber++)
            {
                if (CheckIfCurrNumIsDivisibleBy(numbers, currNumber))
                {
                    Console.Write($"{currNumber} ");
                }
            }
        }

        static bool CheckIfCurrNumIsDivisibleBy(int[] dividers, int currNum)
        {
            for (int i = 0; i < dividers.Length; i++)
            {
                int currDivider = dividers[i];

                if (currNum % currDivider != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
