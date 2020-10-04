using System;
using System.Linq;

namespace _02.Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            PrintResult(GetArrayLenght, GetArraySum, numbers);
        }

        static int GetArrayLenght(int[] numbers)
        {
            return numbers.Length;
        }

        static int GetArraySum(int[] numbers)
        {
            return numbers.Sum();
        }

        static void PrintResult(Func<int[], int> lenght, Func<int[], int> sum, int[] numbers)
        {
            Console.WriteLine(lenght(numbers));
            Console.WriteLine(sum(numbers));
        }
    }
}
